using BusinessLayer.Abstrsact;
using DTOLayer.TestimonialDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : BaseController
    {
      
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        [Authorize()]
        public IActionResult Index()
        {
            var testimonials = _testimonialService.TGetAll().Data;
            return View(testimonials);
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult AddTestimonial(TestimonialCreateDTOs testimonialDTOs,IFormFile photoUrl)
        {
            if (photoUrl == null || photoUrl.Length == 0)
            {
                ModelState.Clear();
                return View(testimonialDTOs);
            }
            var result = _testimonialService.TAdd(testimonialDTOs,photoUrl, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(testimonialDTOs);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdateTestimonial(int id)
        {
            var testimonial = _testimonialService.TGetById(id).Data;
            return View(testimonial);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdateTestimonial(TestimonialDTOs testimonialDTOs,IFormFile photoUrl)
        {
            var result = _testimonialService.TUpdate(testimonialDTOs, photoUrl, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(testimonialDTOs);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id).Data;
            _testimonialService.TDelete(value);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult HardDeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id).Data;
            _testimonialService.THardDelete(value);
            return RedirectToAction("Index");
        }
    }
}
