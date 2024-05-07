using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
