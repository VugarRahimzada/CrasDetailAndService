using BusinessLayer.BaseMessage;
using DTOLayer.OrderDTO;
using EntityLayer.Models;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidations
{
    public class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
           
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);

         
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200);

          
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200)
                .EmailAddress().WithMessage(ValidationBaseMessage.EMAIL);

          
            RuleFor(x => x.LicensePlate)
                .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);
        }
    }
}
