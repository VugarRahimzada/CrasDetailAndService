using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogservice;

        public BlogController(IBlogService blogservice)
        {
            _blogservice = blogservice;
        }

        public IActionResult Index()
        {
            var value = _blogservice.TGetActiv();
            return View(value);
        }
        public IActionResult BlogDetail()
        {
            return View();
        }
    }
}
