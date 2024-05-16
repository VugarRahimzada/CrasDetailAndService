using BusinessLayer.Abstrsact;
using DTOLayer.TestimonialDTO;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
      
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var testimonials = _testimonialService.TGetAll().Data;
            return View(testimonials);
        }


        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(TestimonialCreateDTOs testimonialDTOs)
        {
            var value = _testimonialService.TAdd(testimonialDTOs);
            if (value.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var testimonial = _testimonialService.TGetById(id).Data;
            return View(testimonial);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(TestimonialDTOs testimonialDTOs)
        {
            var result = _testimonialService.TUpdate(testimonialDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(testimonialDTOs);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id).Data;
            _testimonialService.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult HardDeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id).Data;
            _testimonialService.THardDelete(value);
            return RedirectToAction("Index");
        }
    }
}
