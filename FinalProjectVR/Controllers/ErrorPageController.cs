using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }
        public IActionResult AccesDenied()
        {
            return View();
        }

    }
}
