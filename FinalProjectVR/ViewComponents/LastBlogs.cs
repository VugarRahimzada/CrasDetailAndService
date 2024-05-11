using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.ViewComponents
{
    public class LastBlogs :ViewComponent
    {
        private readonly IBlogService _blogService;

        public LastBlogs(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var value =  _blogService.TLastBlog();
            return View(value);
        }
    }
}
