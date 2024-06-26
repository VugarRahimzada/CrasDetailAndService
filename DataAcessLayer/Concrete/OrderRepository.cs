﻿using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class OrderRepository : GenericRepository<Order, AppDbContext>, IOrderRepository
    {

        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Order FirstOrDefault(Expression<Func<Order, bool>> filter)
        {
            return _appDbContext.Orders.FirstOrDefault(filter);
        }
        public List<Order> CheckOrderDeadline(Expression<Func<Order, bool>> filter)
        {
            var value = _appDbContext.Orders.Where(filter).ToList();


            foreach (var item in value)
            {
                item.Delete = item.Id;

            }
            _appDbContext.SaveChanges();
            return value;
        }

        public List<Order> GetOrderWithPricingCategory()
        {
            var data = _appDbContext.Orders.Include(x => x.Pricing).ToList();
            return data;

        }

        public bool Any(Expression<Func<Order, bool>> filter)
        {
            var result = _appDbContext.Orders.Any(filter);
            return result;
        }
    }
}
