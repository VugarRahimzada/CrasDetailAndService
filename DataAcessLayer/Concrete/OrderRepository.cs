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
    }
}
