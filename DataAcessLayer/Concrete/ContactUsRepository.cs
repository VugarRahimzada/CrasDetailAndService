using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;

namespace DataAccessLayer.Concrete
{
    public class ContactUsRepository : GenericRepository<ContactUs, AppDbContext>, IContactUsRepository
    {

    }

}


