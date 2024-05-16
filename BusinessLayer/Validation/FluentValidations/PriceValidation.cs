using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class PriceValidation : AbstractValidator<Pricing>
    {
        public PriceValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Title).MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200);
            RuleFor(x => x.Title).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Price).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage(ValidationBaseMessage.NEGATİVE);
        }
    }

}
