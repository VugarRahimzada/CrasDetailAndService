using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.ViewComponents
{
    public class Testimonial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
