using CoreLayer.Results.Concrete;
using DTOLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrsact
{
    public interface IOrderService
    {
        DataResult<List<OrderDTOs>> TGetAll();
        DataResult<List<OrderDTOs>> TGetActiv();
        DataResult<OrderDTOs> TGetById(int id);
        Result TAdd(OrderDTOs entity);
        Result TUpdate(OrderDTOs entity);
        Result TDelete(OrderDTOs entity);
        Result THardDelete(OrderDTOs entity);
    }
}
