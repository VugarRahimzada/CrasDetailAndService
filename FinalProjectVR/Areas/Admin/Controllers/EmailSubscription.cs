using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmailSubscription : Controller
    {
        private readonly IEmailSubscriptionService _emailSubscriptionService;

        public EmailSubscription(IEmailSubscriptionService emailSubscriptionService)
        {
            _emailSubscriptionService = emailSubscriptionService;
        }

        public IActionResult Index()
        {
            var value = _emailSubscriptionService.TGetAll().Data;
            return View(value);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var value = _emailSubscriptionService.TGetById(id).Data;
            var deletede = _emailSubscriptionService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var value = _emailSubscriptionService.TGetById(id).Data;
            var deletede = _emailSubscriptionService.THardDelete(value);
            return RedirectToAction("Index");
        }
    }
}
