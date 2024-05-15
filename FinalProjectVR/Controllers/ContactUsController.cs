using BusinessLayer.Abstrsact;
using DTOLayer;
using DTOLayer.ContactUs;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class ContactUsController : Controller
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

            _contactusservice.TAdd(contactUs);

            return RedirectToAction("Index");
        }
    }
}
