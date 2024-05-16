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
        private readonly AppDbContext _appDbContext;
        public BlogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Blog LastOrDefault(Expression<Func<Blog, bool>> filter)
        {
            return _appDbContext.Blogs.OrderBy(post => post.CreateTime)
                                     .LastOrDefault(filter);
        }
        public List<Blog> LastBlog(Expression<Func<Blog, bool>> filter)
        {
            return _appDbContext.Blogs.Where(filter)
                                     .OrderByDescending(x => x.CreateTime)
                                     .Take(DefaultConstantValue.LASTBLOG)
                                     .ToList();
        }

        public void IncreesCommentCounta(int id)
        {
            _appDbContext.Blogs.Find(id).CommentCounta++;
            _appDbContext.SaveChanges();
        }

    }

}


