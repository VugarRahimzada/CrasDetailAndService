using BusinessLayer.Abstrsact;
using CoreLayer.Results.Concrete;
using DTOLayer;
using DTOLayer.ContactUs;
using EntityLayer.Models;
using FinalProjectVR.Areas.Admin.Controllers;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class ContactUsController : BaseController
    {
        private readonly IContactUsService _contactusservice;

        public ContactUsController(IContactUsService contactusservice)
        {
            _contactusservice = contactusservice;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(ContactUsCreateDTOs contactUs)
        {

            var result = _contactusservice.TAdd(contactUs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(contactUs);
            }
            return RedirectToAction("Index");
        }
    }
}
