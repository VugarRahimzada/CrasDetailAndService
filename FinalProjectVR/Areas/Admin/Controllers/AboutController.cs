using BusinessLayer.Abstrsact;
using DTOLayer;
using DTOLayer.AboutDTO;
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
            ViewBag.ShowButton = about.Count() == 0;
            return View(about);
        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAbout(AboutCreate aboutDTOs)
        {
            var result = _aboutService.TAdd(aboutDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(aboutDTOs);
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

        [HttpPost]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id).Data;
            _aboutService.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
