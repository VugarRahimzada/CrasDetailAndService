using BusinessLayer.Abstrsact;
using DTOLayer;
using DTOLayer.AboutDTO;
using DTOLayer.PricingDTO;
using EntityLayer.Models;
using FluentValidation;
using FluentValidation.Results;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;
        private readonly IValidator<About> _validator;
        public AboutController(IAboutService aboutService, IValidator<About> validator)
        {
            _aboutService = aboutService;
            _validator = validator;
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

            var result = _aboutService.TAdd(aboutDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(aboutDTOs);
            }
            return RedirectToAction("Index");
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
            var result = _aboutService.TUpdate(aboutDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(aboutDTOs);
            }
            return RedirectToAction("Index");
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
