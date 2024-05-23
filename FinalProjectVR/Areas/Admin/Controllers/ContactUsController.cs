using BusinessLayer.Abstrsact;
using CoreLayer.Entity;
using CoreLayer.Results.Concrete;
using DTOLayer;
using DTOLayer.AboutDTO;
using DTOLayer.ContactUs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactUsController : BaseController
    {

        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var value = _contactUsService.TGetAll();
            return View(value);
        }
        [HttpGet]
        public IActionResult UpdateContactUs(int id)
        {
            var value = _contactUsService.TGetById(id).Data;
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateContactUs(ContactUsUpdateDTOs contactUsDTOs)
        {
            var result = _contactUsService.TUpdate(contactUsDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(contactUsDTOs);
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteContactUs(int id)
        {
            var value = _contactUsService.TGetById(id).Data;
            _contactUsService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult HardDeleteContactUs(int id)
        {
            var value = _contactUsService.TGetById(id).Data;
            _contactUsService.THardDelete(value);
            return RedirectToAction("Index");
        }

    }
}
