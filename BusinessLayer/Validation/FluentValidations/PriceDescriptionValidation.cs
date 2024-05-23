using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class PriceDescriptionValidation : AbstractValidator<PriceDescription>
    {
        public PriceDescriptionValidation()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200);
        }
    }
}
