using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer.PricingDTO;
using EntityLayer.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrsact
{
    public interface IPricingService
    {
        IDataResult<List<PricingDTOs>> TGetAll();

        IDataResult<List<PricingActivDTOs>> TGetActiv();
        IDataResult<PricingDTOs> TGetById(int id);
        IResult TAdd(PricingCreateDTOs entity, out List<ValidationFailure> errors);
        IResult TUpdate(PricingUpdateDTOs entity, out List<ValidationFailure> errors);
        IResult TDelete(PricingDTOs entity);
        IResult THardDelete(PricingDTOs entity);
    }
}

