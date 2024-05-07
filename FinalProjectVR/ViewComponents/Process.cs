using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.ViewComponents
{
    public class Process:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
