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
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Name).MaximumLength(50).WithMessage(ValidationBaseMessage.MAX_LENGHT_50);
            RuleFor(x => x.Name).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Email).MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200);
            RuleFor(x => x.Email).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ValidationBaseMessage.EMAIL);

            RuleFor(x => x.Message).NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY);
            RuleFor(x => x.Message).MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);
            RuleFor(x => x.Message).MaximumLength(1000).WithMessage(ValidationBaseMessage.MAX_LENGHT_1000);

        }
    }
}
