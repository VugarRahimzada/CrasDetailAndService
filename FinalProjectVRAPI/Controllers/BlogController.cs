using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVRAPI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        [HttpGet]
        public IActionResult GetAllBlog()
        {
            var value = _blogService.TGetAll();
            return View(value);
        }
    }
}
