using BusinessLayer.BaseMessage;
using EntityLayer.Models;
using FluentValidation;

public class FAQValidation : AbstractValidator<FAQ>
{
    public FAQValidation()
    {
 
        RuleFor(x => x.Question)
            .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
            .MaximumLength(200).WithMessage(ValidationBaseMessage.MAX_LENGHT_200)
            .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);

  
        RuleFor(x => x.Answer)
            .NotEmpty().WithMessage(ValidationBaseMessage.NOT_EMPTY)
            .MaximumLength(1000).WithMessage(ValidationBaseMessage.MAX_LENGHT_1000)
            .MinimumLength(3).WithMessage(ValidationBaseMessage.MIN_LENGHT);
    }
}

