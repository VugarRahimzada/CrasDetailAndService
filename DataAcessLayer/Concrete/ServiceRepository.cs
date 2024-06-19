using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class ServiceRepository : GenericRepository<Service, AppDbContext>, IServiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public ServiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Service> GetServiceHomePage(Expression<Func<Service, bool>> function)
        {
            var value = _appDbContext.Services.Where(function).Where(x => x.Delete == 0).ToList();
            return value;
        }
    }

}


