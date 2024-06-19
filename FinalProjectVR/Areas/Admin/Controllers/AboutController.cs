using BusinessLayer.Abstrsact;
using DTOLayer.AboutDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var about = _aboutService.TGetAll().Data;
            ViewBag.ShowButton = about.Count() == 0;
            return View(about);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult AddAbout(AboutCreateDTOs aboutDTOs)
        {

            var result = _aboutService.TAdd(aboutDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(aboutDTOs);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdateAbout(int id)
        {
            var about = _aboutService.TGetById(id).Data;
            return View(about);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdateAbout(AboutUpdateDTOs aboutDTOs)
        {
            var result = _aboutService.TUpdate(aboutDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(aboutDTOs);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id).Data;
            _aboutService.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
