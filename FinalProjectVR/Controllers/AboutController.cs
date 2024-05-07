using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
