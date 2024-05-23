using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class TestimonialValidation : AbstractValidator<Testimonial>
    {
        public TestimonialValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200);

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(2000).WithMessage(ValidationBaseMessage.MAX_LENGHT_1000);
        }
    }
}
