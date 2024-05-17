using CoreLayer.DataAccess.Abstract;
using EntityLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        List<Service> GetServiceHomePage(Expression<Func<Service, bool>> function);
    }

}
