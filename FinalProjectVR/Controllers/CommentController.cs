using BusinessLayer.Abstrsact;
using CoreLayer.Results.Concrete;
using DTOLayer.AboutDTO;
using DTOLayer.BlogDTO;
using DTOLayer.CommentDTO;
using FinalProjectVR.Areas.Admin.Controllers;
using FluentValidation.Results;
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
        public IActionResult CommentAdd(CommentCreateDTOs commentDTOs, int BlogId)
        {
           var result =  _commentService.TAdd(commentDTOs);
            if (result.IsSuccess)
            {
                 return RedirectToAction("BlogDetail", "Blog", new { id = BlogId });
            }

                return View(commentDTOs);
        }
    }
}
