using BusinessLayer.Abstrsact;
using DocumentFormat.OpenXml.Office2010.Excel;
using DTOLayer;
using DTOLayer.BlogDTO;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
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
        public IActionResult AddBlog(BlogDTOs blogDTOs)
        {
            var result = _blogService.TAdd(blogDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(blogDTOs);
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogService.TGetById(id).Data;
            return View(blog);
        }

        [HttpPost]
        public IActionResult UpdateBlog(BlogDTOs blogDTOs)
        {
            var result = _blogService.TUpdate(blogDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(blogDTOs);
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
