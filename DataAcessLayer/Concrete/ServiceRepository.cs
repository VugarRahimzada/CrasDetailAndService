using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;

namespace DataAccessLayer.Concrete
{
    public class ServiceRepository : GenericRepository<Service, AppDbContext>, IServiceRepository
    {
        //public ServiceRepository(AppDbContext context) : base(context)
        //{
        //}
    }

}


