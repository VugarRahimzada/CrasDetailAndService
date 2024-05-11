using CoreLayer.DataAccess.Concrete;
using CoreLayer.DefaultValues;
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
            return AppDbContext.Blogs.OrderBy(post => post.CreateTime)
                                     .LastOrDefault(filter);
        }
        public List<Blog> LastBlog(Expression<Func<Blog, bool>> filter)
        {
            return AppDbContext.Blogs.Where(filter)
                                     .OrderByDescending(x => x.CreateTime)
                                     .Take(DefaultConstantValue.LASTBLOG)
                                     .ToList();
        }
    }

}


