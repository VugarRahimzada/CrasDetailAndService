using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class CommentListAdmin:ViewComponent

    {
        private readonly ICommentService _commentService;

        public CommentListAdmin(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var value = _commentService.TGetCommentsById(id).Data;
            return View(value);
        }
    }
}
