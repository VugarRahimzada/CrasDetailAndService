using BusinessLayer.Abstrsact;
using CoreLayer.Results.Concrete;
using DTOLayer.BlogDTO;
using DTOLayer.CommentDTO;
using FinalProjectVR.Areas.Admin.Controllers;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace FinalProjectVR.Controllers
{
    public class CommentController : BaseController
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
        public IActionResult CommentAdd(CommentCreateDTOs commentDTOs, int BlogId)
        {
           var result =  _commentService.TAdd(commentDTOs, out List<ValidationFailure> errors);

            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(commentDTOs);
            }

            return RedirectToAction("BlogDetail", "Blog", new { id = BlogId });
        }
    }
}
