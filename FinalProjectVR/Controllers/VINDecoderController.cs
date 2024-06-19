using BusinessLayer.BaseMessage;
using EntityLayer.RapidApi;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class VINDecoderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Decode(string vin)
        {
            if (string.IsNullOrEmpty(vin))
            {
                ViewBag.Error = ValidationBaseMessage.VALID_VIN;
                return View("Index");
            }

            if (vin.Length != 17)
            {
                ViewBag.Error = ValidationBaseMessage.VIN_LENGHT;
                return View("Index");
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://simple-salvage-vin-check.p.rapidapi.com/?DecodeVIN={vin}"),
                Headers =
                {
                    { "x-rapidapi-key", "41c6470f81mshdceba3f7d9b59fbp16e5b3jsn6325c4036ea1" },
                    { "x-rapidapi-host", "simple-salvage-vin-check.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var vinResult = Newtonsoft.Json.JsonConvert.DeserializeObject<VINResult>(body);

                    if (vinResult.Results != null && vinResult.Results.Count > 0)
                    {
                        var result = vinResult.Results[0];
                        ViewBag.Make = result.Make;
                        ViewBag.Model = result.Model;
                        ViewBag.Doors = result.Doors;
                        ViewBag.EngineCylinders = result.EngineCylinders;
                        ViewBag.EngineHP = result.EngineHP;
                    }
                    else
                    {
                        ViewBag.Error = ValidationBaseMessage.VIN_NOT_FOUND;
                    }
                }
                else
                {
                    ViewBag.Error =ValidationBaseMessage.ERROR_DECODİNG_VIN;
                }
            }

            return View("Index");
        }
    }
}
