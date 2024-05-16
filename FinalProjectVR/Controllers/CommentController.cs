using BusinessLayer.Abstrsact;
using DTOLayer.CommentDTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace FinalProjectVR.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpGet]
        public IActionResult CommentAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CommentAdd(CommentCreateDTOs commentDTOs)
        {
            _commentService.TAdd(commentDTOs);
            return RedirectToAction("Index", "Blog");
        }
    }
}
