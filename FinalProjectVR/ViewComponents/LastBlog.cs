using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.ViewComponents
{
    public class LastBlog :  ViewComponent
    {
        private readonly IBlogService _blogService;

        public LastBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _blogService.TLastOrDefault();
            return View(value);
        }
    }
}
