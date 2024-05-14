using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrsact
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetOrderWithPricingCategory();
        IDataResult<List<OrderDTOs>> TGetActiv();
        IDataResult<Order> TGetById(int id);
        IResult TAdd(OrderDTOs entity);
        IResult TUpdate(Order entity);
        IResult TDelete(Order entity);
        IResult THardDelete(Order entity);
        IDataResult<OrderDTOs> FirstOrDefault(string licenseplate);
        IDataResult<MemoryStream> ExportExelOrder();

    }
}
