using BusinessLayer.Abstrsact;
using DTOLayer.ContactUs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : BaseController
    {

        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        [Authorize()]
        public IActionResult Index()
        {
            var value = _contactUsService.TGetAll();
            return View(value);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdateContactUs(int id)
        {
            var value = _contactUsService.TGetById(id).Data;
            return View(value);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdateContactUs(ContactUsDTOs contactUsDTOs)
        {
            var result = _contactUsService.TUpdate(contactUsDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(contactUsDTOs);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult DeleteContactUs(int id)
        {
            var value = _contactUsService.TGetById(id).Data;
            _contactUsService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult HardDeleteContactUs(int id)
        {
            var value = _contactUsService.TGetById(id).Data;
            _contactUsService.THardDelete(value);
            return RedirectToAction("Index");
        }

    }
}
