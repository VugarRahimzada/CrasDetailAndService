using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class PriceDescriptionRepository : GenericRepository<PriceDescription, AppDbContext>, IPriceDescriptionRepository
    {
        AppDbContext contex = new();
        public List<PriceDescription> GetOrderWithPricingCategory()
        {
            var value = contex.PriceDescriptions.Include(x => x.Pricing).ToList();
            return value;
        }
    }

}


