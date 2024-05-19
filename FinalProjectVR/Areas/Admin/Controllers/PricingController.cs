using BusinessLayer.Abstrsact;
using DTOLayer.PricingDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PricingController : Controller
    {
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingservice)
        {
            _pricingService = pricingservice;
        }

        public IActionResult Index()
        {
            var pricing = _pricingService.TGetAll().Data;
            return View(pricing);
        }

        [HttpGet]
        public IActionResult UpdatePricing(int id)
        {
            var pricing = _pricingService.TGetById(id).Data;
            return View(pricing);
        }

        [HttpPost]
        public IActionResult UpdatePricing(PricingDTOs pricingDTOs)
        {
            var result = _pricingService.TUpdate(pricingDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(pricingDTOs);
        }

        [HttpGet]
        public IActionResult AddPricing()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPricing(PricingCreateDTOs pricingDTOs)
        {
            var result = _pricingService.TAdd(pricingDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(pricingDTOs);
        }
        
        public IActionResult DeletePricing(int id)
        {
            var value = _pricingService.TGetById(id).Data;
            _pricingService.TDelete(value);
            return RedirectToAction("Index");

        }
        public IActionResult HardDeletePricing(int id)
        {
            var value = _pricingService.TGetById(id).Data;
            _pricingService.THardDelete(value);
            return RedirectToAction("Index");

        }
    }
}
