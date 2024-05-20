using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class AdminLastBlog: ViewComponent
    {
        private readonly IBlogService _blogService;

        public AdminLastBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _blogService.TLastBlog().Data;
            return View(value);
        }
    }
}
