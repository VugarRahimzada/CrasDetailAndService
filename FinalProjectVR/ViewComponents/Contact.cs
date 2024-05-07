using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.ViewComponents
{
    public class Contact: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
