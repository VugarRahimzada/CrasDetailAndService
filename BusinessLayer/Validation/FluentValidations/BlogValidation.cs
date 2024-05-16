using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Title).MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);
            RuleFor(x => x.Title).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Text).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Text).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);


            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.ImageUrl).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

        }
    }

}
