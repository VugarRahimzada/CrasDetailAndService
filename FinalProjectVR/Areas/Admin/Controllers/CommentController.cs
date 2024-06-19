using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Author,Creator")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public IActionResult DeleteComment(int id)
        {
            var commentDTOs = _commentService.TGetById(id).Data;
            _commentService.TDelete(commentDTOs);
            return RedirectToAction("Index","Blog");
        }


        [HttpPost]
        public IActionResult HardDeleteComment(int id)
        {
            var commentDTOs = _commentService.TGetById(id).Data;
            _commentService.THardDelete(commentDTOs);
            return RedirectToAction("Index","Blog");
        }
    }
}
