using BusinessLayer.BaseMessage;
using DTOLayer.OrderDTO;
using EntityLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.FluentValidations
{
    public class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x=>x.Name).MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);
            RuleFor(x=>x.Name).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Surname).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Surname).MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200); ;
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY); 
            RuleFor(x => x.Email).MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200); 
            RuleFor(x => x.Email).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ValidationBaseMessage.EMAIL);

            RuleFor(x => x.LicensePlate).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.LicensePlate).MaximumLength(50);
            RuleFor(x => x.LicensePlate).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);
        }
    }
}
