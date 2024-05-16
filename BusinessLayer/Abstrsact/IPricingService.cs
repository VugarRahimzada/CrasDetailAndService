using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer.PricingDTO;
using EntityLayer.Models;
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

        IDataResult<List<PricingDTOs>> TGetActiv();
        IDataResult<PricingDTOs> TGetById(int id);
        IResult TAdd(PricingDTOs entity);
        IResult TUpdate(PricingDTOs entity);
        IResult TDelete(PricingDTOs entity);
        IResult THardDelete(PricingDTOs entity);
    }
}
