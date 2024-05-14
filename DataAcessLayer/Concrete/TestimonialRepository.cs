using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;

namespace DataAccessLayer.Concrete
{
    public class TestimonialRepository : GenericRepository<Testimonial, AppDbContext>, ITestimonialRepository
    {
        //public TestimonialRepository(AppDbContext context) : base(context)
        //{
        //}
    }

}


