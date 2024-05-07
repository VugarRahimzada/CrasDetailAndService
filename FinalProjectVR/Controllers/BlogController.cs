using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogDetail()
        {
            return View();
        }
    }
}
