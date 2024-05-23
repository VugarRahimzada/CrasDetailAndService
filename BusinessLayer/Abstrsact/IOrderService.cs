using CoreLayer.Results.Abstract;
using DTOLayer.OrderDTO;
using EntityLayer.Models;
using FluentValidation.Results;
using System.Linq.Expressions;

namespace BusinessLayer.Abstrsact
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetOrderWithPricingCategory();
        IDataResult<List<OrderDTOs>> TGetActiv();
        IDataResult<Order> TGetById(int id);
        IResult TAdd(OrderCreateDTOs entity);
        IResult TUpdate(Order entity, out List<ValidationFailure> errors);
        IResult TDelete(Order entity);
        IResult THardDelete(Order entity);
        IDataResult<OrderDTOs> FirstOrDefault(string licenseplate);
        IDataResult<MemoryStream> ExportExelOrder();
        IDataResult<int> TCount();
    }
}
