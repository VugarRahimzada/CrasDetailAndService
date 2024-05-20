using BusinessLayer.Abstrsact;
using DTOLayer.EmailSubscriptionDTO;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class EmailSubscriptionController : Controller
    {
        private readonly IEmailSubscriptionService _emailSubscriptionService;

        public EmailSubscriptionController(IEmailSubscriptionService emailSubscriptionService)
        {
            _emailSubscriptionService = emailSubscriptionService;
        }
        [HttpGet]
        public PartialViewResult EmailSubscription()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult EmailSubscription(EmailSubscriptionCreateDTOs emailSubscriptionCreateDTOs)
        {
            _emailSubscriptionService.TAdd(emailSubscriptionCreateDTOs);
            return RedirectToAction("Index" , "Home");
        }
    }
}
