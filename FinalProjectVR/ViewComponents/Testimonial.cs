using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.ViewComponents
{
    public class Testimonial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public Testimonial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _testimonialService.TGetActiv().Data;
            return View(value);
        }
    }
}
