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
    public class EmailSubscriptionValidation : AbstractValidator<EmailSubscription>
    {
        public EmailSubscriptionValidation()
        {
            RuleFor(x=>x.Email)
                   .NotEmpty()
                   .EmailAddress()
                   .WithMessage(ValidationBaseMessage.EMAIL);
        }
    }
}
