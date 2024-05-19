using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{

    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var value =_aboutService.TGetActiv().Data;
            return View(value);
        }
    }
}
