using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class FAQController : Controller
    {
        private readonly IFAQService _faqService;

		public FAQController(IFAQService faqService)
		{
			_faqService = faqService;
		}

		public IActionResult Index()
        {
            var value = _faqService.TGetActiv().Data;
            return View(value);
        }
    }
}
