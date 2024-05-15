using BusinessLayer.Abstrsact;
using DTOLayer;
using DTOLayer.FAQDTO;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FAQController : Controller
    {
        private readonly IFAQService _faqService;

        public FAQController(IFAQService faqService)
        {
            _faqService = faqService;
        }

        public IActionResult Index()
        {
            var faqs = _faqService.TGetAll().Data;
            return View(faqs);
        }
        [HttpGet]
        public IActionResult AddFAQ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFAQ(FAQCreateDTOs faqdtos)
        {
            var value = _faqService.TAdd(faqdtos);
            if (value.IsSuccess)
            {  
            return RedirectToAction("Index");
            }
            return View(faqdtos);
        }


        [HttpGet]
        public IActionResult UpdateFAQ(int id)
        {
            var faq = _faqService.TGetById(id).Data;
            return View(faq);
        }

        [HttpPost]
        public IActionResult UpdateFAQ(FAQDTOs faqDTOs)
        {
            var result = _faqService.TUpdate(faqDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(faqDTOs);
        }

        public IActionResult DeleteFAQ(int id)
        {
            var value = _faqService.TGetById(id).Data;
            _faqService.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult HardDeleteFAQ(int id)
        {
            var value = _faqService.TGetById(id).Data;
            _faqService.THardDelete(value);
            return RedirectToAction("Index");
        }

    }
}

