using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class ServiceValidation : AbstractValidator<Service>
    {
        public ServiceValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(1000).WithMessage(ValidationBaseMessage.MAX_LENGHT_1000);

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
        }
    }
}
