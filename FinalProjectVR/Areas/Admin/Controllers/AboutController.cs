using BusinessLayer.Abstrsact;
using DTOLayer;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var about = _aboutService.TGetAll().Data;
            return View(about);
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var about = _aboutService.TGetById(id).Data;
            return View(about);
        }

        [HttpPost]
        public IActionResult UpdateAbout(AboutDTOs aboutDTOs)
        {
            var result = _aboutService.TUpdate(aboutDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(aboutDTOs);
        }

        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id).Data;
            _aboutService.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
