﻿using AutoMapper;
using BusinessLayer.Abstrsact;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Result TAdd(OrderDTOs entity)
        {

            var order = _mapper.Map<Order>(entity);
            _orderRepository.Add(order);
            return new Result("Uğurla Əlavə Edildi", true);
        }

        public Result TDelete(OrderDTOs entity)
        {
            throw new NotImplementedException();
        }

        public DataResult<List<OrderDTOs>> TGetActiv()
        {
            throw new NotImplementedException();
        }

        public DataResult<List<OrderDTOs>> TGetAll()
        {
            throw new NotImplementedException();
        }

        public DataResult<OrderDTOs> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Result THardDelete(OrderDTOs entity)
        {
            throw new NotImplementedException();
        }

        public Result TUpdate(OrderDTOs entity)
        {
            throw new NotImplementedException();
        }
    }
}
