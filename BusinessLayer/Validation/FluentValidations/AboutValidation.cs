using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.FluentValidations
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(x => x.Misson)
                   .NotEmpty()
                   .WithMessage("Boş buraxıla bilməz")
                   .MinimumLength(3)
                   .WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Vision)
                   .NotEmpty()
                   .WithMessage("Boş buraxıla bilməz")
                   .MinimumLength(3)
                   .WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.History)
                   .NotEmpty()
                   .WithMessage(ValidationBaseMessage.NOT_EMPTY)
                   .MinimumLength(3)
                   .WithMessage(ValidationBaseMessage.MIN_LENGHT);
        }
    }
}
