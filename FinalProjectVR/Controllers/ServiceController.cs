using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ServiceDetail()
        {
            return View();
        }
    }
}
