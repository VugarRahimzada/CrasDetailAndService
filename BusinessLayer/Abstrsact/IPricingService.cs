using CoreLayer.Results.Concrete;
using DTOLayer;
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
        DataResult<List<PricingDTOs>> TGetAll();

        DataResult<List<PricingDTOs>> TGetActiv();
        DataResult<PricingDTOs> TGetById(int id);
        Result TAdd(PricingDTOs entity);
        Result TUpdate(PricingDTOs entity);
        Result TDelete(PricingDTOs entity);
        Result THardDelete(PricingDTOs entity);
    }
}
