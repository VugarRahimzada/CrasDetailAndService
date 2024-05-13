using CoreLayer.DataAccess.Abstract;
using CoreLayer.DataAccess.Concrete;
using DTOLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IOrderRepository :IGenericRepository<Order>
    {

        Order FirstOrDefault(Expression<Func<Order, bool>> filter);
        List<Order> CheckOrderDeadline(Expression<Func<Order, bool>> filter);
    }
}
