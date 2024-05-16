using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class PriceDescriptionRepository : GenericRepository<PriceDescription, AppDbContext>, IPriceDescriptionRepository
    {
        private readonly AppDbContext _appDbContext;

        public PriceDescriptionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<PriceDescription> GetOrderWithPricingCategory()
        {
            var value = _appDbContext.PriceDescriptions.Include(x => x.Pricing).ToList();
            return value;
        }
    }

}


