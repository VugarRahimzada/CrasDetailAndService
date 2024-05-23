using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class PriceValidation : AbstractValidator<Pricing>
    {
        public PriceValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200);

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .GreaterThanOrEqualTo(0).WithMessage(ValidationBaseMessage.NEGATİVE);
        }
    }
}
