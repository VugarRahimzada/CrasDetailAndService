using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class FAQValidation : AbstractValidator<FAQ>
    {
        public FAQValidation()
        {
            RuleFor(x => x.Question).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Question).MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200);
            RuleFor(x => x.Question).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Answer).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Answer).MaximumLength(1000).WithMessage(ValidationBaseMessage.MAX_LENGHT_1000);
            RuleFor(x => x.Answer).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);
        }
    }

}
