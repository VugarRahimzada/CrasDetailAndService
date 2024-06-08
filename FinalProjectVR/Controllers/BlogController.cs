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
          
            var value = _blogservice.TGetActiv().Data;
            return View(value);
        }
        public IActionResult BlogDetail(int id)
        {
            ViewBag.i = id;
            var valubyid =  _blogservice.TGetById(id).Data;
            return View(valubyid);
        }
    }
}
