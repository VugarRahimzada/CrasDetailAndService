using CoreLayer.Results.Abstract;
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
        IDataResult<List<OrderDTOs>> TGetAll();
        IDataResult<List<OrderDTOs>> TGetActiv();
        IDataResult<OrderDTOs> TGetById(int id);
        IResult TAdd(OrderDTOs entity);
        IResult TUpdate(OrderDTOs entity);
        IResult TDelete(OrderDTOs entity);
        IResult THardDelete(OrderDTOs entity);

    }
}
