using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MaximumLength(50)
                .WithMessage(ValidationBaseMessage.MAX_LENGHT_50)
                .MinimumLength(3)
                .WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3)
                .WithMessage(ValidationBaseMessage.MIN_LENGHT);


            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3)
                .WithMessage(ValidationBaseMessage.MIN_LENGHT);

            //RuleFor(x => x.photoUrl)
            //    .NotEmpty()
            //    .WithMessage(ValidationBaseMessage.NOT_EMPTY);

        }
    }

}
