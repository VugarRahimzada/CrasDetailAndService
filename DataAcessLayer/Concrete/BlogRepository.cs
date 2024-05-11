using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class BlogRepository : GenericRepository<Blog, AppDbContext>, IBlogRepository
    {
        AppDbContext AppDbContext = new AppDbContext();
        public Blog LastOrDefault(Expression<Func<Blog, bool>> filter)
        {
            return AppDbContext.Blogs.OrderBy(post => post.CreateTime).LastOrDefault(filter);
        }
    }

}


