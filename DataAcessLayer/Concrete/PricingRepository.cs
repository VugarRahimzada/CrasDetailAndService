using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;

namespace DataAccessLayer.Concrete
{
    public class PricingRepository : GenericRepository<Pricing, AppDbContext>, IPricingRepository
    {
        //public PricingRepository(AppDbContext context) : base(context)
        //{
        //}
    }

}


