using CoreLayer.DataAccess.Abstract;
using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class OrderRepository : GenericRepository<Order, AppDbContext>, IOrderRepository
    {

        AppDbContext _appDbContext = new AppDbContext();



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

            //var result = (from order in _appDbContext.Orders
            //              join pricing in _appDbContext.Pricings
            //              on order.PricingId equals pricing.Id
            //              select order).ToList();

            return data;

        }
    }
}
