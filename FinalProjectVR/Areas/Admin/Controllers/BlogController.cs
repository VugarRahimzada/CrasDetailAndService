using BusinessLayer.Abstrsact;
using DTOLayer.BlogDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : BaseController
    {

        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [Authorize]

        public IActionResult Index()
        {
            var value = _blogService.TGetAll().Data;
            return View(value);
        }
        [Authorize(Roles = "Admin,Author,Creator")]
        public IActionResult DetailBlog(BlogDTOs blogDTOs)
        {
            ViewBag.i = blogDTOs.Id;
            var value = _blogService.TGetById(blogDTOs.Id).Data;
            return View(value);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Author,Creator")]
        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Author,Creator")]
        public IActionResult AddBlog(BlogCreateDTO blogDTOs, IFormFile photoUrl)
        {
            var result = _blogService.TAdd(blogDTOs, photoUrl, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(blogDTOs);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Author,Creator")]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogService.TGetById(id).Data;
            return View(blog);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Author,Creator")]
        public IActionResult UpdateBlog(BlogDTOs blogDTOs, IFormFile photoUrl)
        {
            var result = _blogService.TUpdate(blogDTOs,photoUrl, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(blogDTOs);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Author,Creator")]
        public IActionResult DeleteBlog(int id)
        {
            var blog = _blogService.TGetById(id).Data;
            _blogService.TDelete(blog);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Author,Creator")]
        public IActionResult HardDeleteBlog(int id)
        {
            var blog = _blogService.TGetById(id).Data;
            _blogService.THardDelete(blog);
            return RedirectToAction("Index");
        }
    }
}
