using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    public abstract class BaseController : Controller
    {
        protected void AddModelError(List<ValidationFailure> errors)
        {
            ModelState.Clear();
            foreach (var error in errors)
            {
                ModelState.AddModelError($"{error.PropertyName}", error.ErrorMessage);
            }
        }
    }
}