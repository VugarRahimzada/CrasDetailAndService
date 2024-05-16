using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.FluentValidations
{
    public class AppointmentValidation : AbstractValidator<Appointment>
    {
        public AppointmentValidation()
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

            RuleFor(x => x.Phone).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Phone).MaximumLength(20).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);
            RuleFor(x => x.Phone).Matches(@"^\+?\d{7,15}$").WithMessage(ValidationBaseMessage.PHONE_NUMBER);



            RuleFor(x => x.VehicelType).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.VehicelType).MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);
            RuleFor(x => x.VehicelType).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Message).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Message).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);
            RuleFor(x => x.Message).MaximumLength(1000).WithMessage(ValidationBaseMessage.MAX_LENGHT_1000);

            RuleFor(x => x.SelectDate).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
        }
    }
}
