using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.Validation.FluentValidations;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderManager(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IDataResult<OrderDTOs> FirstOrDefault(string licenseplate)
        {
            var orderplate = _orderRepository.FirstOrDefault(x => x.LicensePlate == licenseplate);
            var orderplatedto = _mapper.Map<OrderDTOs>(orderplate);

            return new SuccessDataResult<OrderDTOs>(orderplatedto);
        }

        public IResult TAdd(OrderDTOs entity)
        {
            var validation = new OrderValidation();
            var validationresult = validation.Validate(entity);
            if (!validationresult.IsValid)
            {
                throw new Exception();
            }          
            var order = _mapper.Map<Order>(entity);
            _orderRepository.Add(order);
            return new SuccessResult("Uğurla Əlavə Edildi");
        }

        public IResult TDelete(OrderDTOs entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OrderDTOs>> TGetActiv()
        {
            var order = _orderRepository.GetActiv();
       
            var oderderdto  = _mapper.Map<List<OrderDTOs>>(order);
            return new SuccessDataResult<List<OrderDTOs>>(oderderdto, "Uğurla Əlavə Edildi");

        }

        public IDataResult<List<OrderDTOs>> TGetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<OrderDTOs> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult THardDelete(OrderDTOs entity)
        {
            throw new NotImplementedException();
        }

        public IResult TUpdate(OrderDTOs entity)
        {
            throw new NotImplementedException();
        }
    }
}
