using BusinessLayer.Abstrsact;
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
            var value = _contactUsService.TGetActiv();
            return View(value);
        }
    }
}
