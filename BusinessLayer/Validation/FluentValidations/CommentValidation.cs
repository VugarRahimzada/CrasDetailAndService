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
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MaximumLength(50)
                .WithMessage(ValidationBaseMessage.MAX_LENGHT_50)
                .MinimumLength(3)
                .WithMessage(ValidationBaseMessage.MIN_LENGHT);


            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MaximumLength(200)
                .WithMessage(ValidationBaseMessage.MAX_LENGHT_200)
                .EmailAddress()
                .WithMessage(ValidationBaseMessage.EMAIL)
                .MinimumLength(3)
                .WithMessage(ValidationBaseMessage.MIN_LENGHT);


            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage(ValidationBaseMessage.NOT_EMPTY)
                .MinimumLength(3)
                .WithMessage(ValidationBaseMessage.MIN_LENGHT)
                .MaximumLength(1000)
                .WithMessage(ValidationBaseMessage.MAX_LENGHT_1000);

        }
    }
}
