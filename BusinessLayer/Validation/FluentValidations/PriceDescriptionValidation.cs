using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class PriceDescriptionValidation : AbstractValidator<PriceDescription>
    {
        public PriceDescriptionValidation()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Description).MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200);
            RuleFor(x => x.Description).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);
        }
    }

}
