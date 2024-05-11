using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.ViewComponents
{
    public class CommentList : ViewComponent
    {
        private readonly ICommentService _commentService;

        public CommentList(ICommentService commentService)
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
