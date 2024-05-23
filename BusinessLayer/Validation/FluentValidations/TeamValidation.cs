using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class TeamValidation : AbstractValidator<Team>
    {
        public TeamValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200);

            RuleFor(x => x.Position)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200);

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.LinkedInUrl)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
        }
    }
}
