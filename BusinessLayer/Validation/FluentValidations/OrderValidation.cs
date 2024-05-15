using DTOLayer.OrderDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.FluentValidations
{
    public class OrderValidation : AbstractValidator<OrderDTOs>
    {
        public OrderValidation()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Name).MaximumLength(50);
            RuleFor(x=>x.Name).MinimumLength(3);
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Surname).MaximumLength(200);
            RuleFor(x => x.Surname).MinimumLength(3);
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).MaximumLength(200);
            RuleFor(x => x.Email).MinimumLength(3);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.LicensePlate).NotEmpty();
            RuleFor(x => x.LicensePlate).MaximumLength(50);
            RuleFor(x => x.LicensePlate).MinimumLength(3);
        }
    }
}
