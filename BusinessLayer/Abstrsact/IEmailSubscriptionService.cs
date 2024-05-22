using CoreLayer.Results.Abstract;
using DTOLayer.AppointmentDTO;
using DTOLayer.EmailSubscriptionDTO;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrsact
{
    public interface IEmailSubscriptionService
    {
        IDataResult<List<EmailSubscriptionDTOs>> TGetAll();
        IDataResult<List<EmailSubscriptionDTOs>> TGetActiv();
        IDataResult<EmailSubscriptionDTOs> TGetById(int id);
        IResult TAdd(EmailSubscriptionCreateDTOs entity);
        IResult TUpdate(EmailSubscriptionDTOs entity);
        IResult TDelete(EmailSubscriptionDTOs entity);
        IResult THardDelete(EmailSubscriptionDTOs entity);
        IDataResult<int> TCount();
    }
}
