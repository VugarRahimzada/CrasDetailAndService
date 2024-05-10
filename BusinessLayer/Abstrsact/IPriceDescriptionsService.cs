using CoreLayer.Results.Concrete;
using DTOLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrsact
{
    public interface IPriceDescriptionsService
    {
        DataResult<List<PriceDescriptionDTOs>> TGetAll();
        DataResult<List<PriceDescriptionDTOs>> TGetActiv();
        DataResult<PriceDescriptionDTOs> TGetById(int id);
        Result TAdd(PriceDescriptionDTOs entity);
        Result TUpdate(PriceDescriptionDTOs entity);
        Result TDelete(PriceDescriptionDTOs entity);
        Result THardDelete(PriceDescriptionDTOs entity);
        DataResult<List<PriceDescriptionDTOs>> TGetActivByPricingId(int pricingId);
    }
}
