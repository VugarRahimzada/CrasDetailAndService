using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class ContactUsValidation : AbstractValidator<ContactUs>
    {
        public ContactUsValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Name).MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);
            RuleFor(x => x.Name).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Surname).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Surname).MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200);
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Email).MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);
            RuleFor(x => x.Email).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Message).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Message).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);
            RuleFor(x => x.Message).MaximumLength(1000).WithMessage(ValidationBaseMessage.MAX_LENGHT_1000);

            RuleFor(x => x.Subject).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);
        }
    }

}
