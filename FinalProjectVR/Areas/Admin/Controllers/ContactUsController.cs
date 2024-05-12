using BusinessLayer.Abstrsact;
using DTOLayer;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
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
        public IActionResult UpdateContactUs(ContactUsDTOs contactUsDTOs)
        {
            var value = _contactUsService.TUpdate(contactUsDTOs);
            if(value.IsSuccess)
            {
                
            return RedirectToAction("Index");
            }
            return View(contactUsDTOs);
        }
        public IActionResult DeleteContactUs(int id)
        {
            var value = _contactUsService.TGetById(id).Data;
            _contactUsService.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult HardDeleteContactUs(int id)
        {
            var value = _contactUsService.TGetById(id).Data;
            _contactUsService.THardDelete(value);
            return RedirectToAction("Index");
        }

    }
}
