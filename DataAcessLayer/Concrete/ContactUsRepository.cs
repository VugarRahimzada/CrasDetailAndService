using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DTOLayer;
using EntityLayer.Models;

namespace DataAccessLayer.Concrete
{
    public class ContactUsRepository : GenericRepository<ContactUs, AppDbContext>, IContactUsRepository
    {
        //public ContactUsRepository(AppDbContext context) : base(context)
        //{
        //}
    }

}


