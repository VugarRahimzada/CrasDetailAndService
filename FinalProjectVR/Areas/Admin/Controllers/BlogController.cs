using BusinessLayer.Abstrsact;
using DTOLayer.BlogDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Author")]
    public class BlogController : BaseController
    {

        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var value = _blogService.TGetAll().Data;
            return View(value);
        }

        public IActionResult DetailBlog(BlogDTOs blogDTOs)
        {
            ViewBag.i = blogDTOs.Id;
            var value = _blogService.TGetById(blogDTOs.Id).Data;
            return View(value);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(BlogCreateDTO blogDTOs, IFormFile photoUrl)
        {
            //if (photoUrl == null || photoUrl.Length == 0)
            //{
            //    ModelState.Clear();
            //    return View(blogDTOs);
            //}

            var result = _blogService.TAdd(blogDTOs, photoUrl, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(blogDTOs);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogService.TGetById(id).Data;
            return View(blog);
        }

        [HttpPost]
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
        public IActionResult DeleteBlog(int id)
        {
            var blog = _blogService.TGetById(id).Data;
            _blogService.TDelete(blog);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult HardDeleteBlog(int id)
        {
            var blog = _blogService.TGetById(id).Data;
            _blogService.THardDelete(blog);
            return RedirectToAction("Index");
        }
    }
}
