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
        AppDbContext Context = new AppDbContext();
        //public BlogRepository(AppDbContext context):base(context)
        //{
        //}
        public Blog LastOrDefault(Expression<Func<Blog, bool>> filter)
        {
            return Context.Blogs.OrderBy(post => post.CreateTime)
                                     .LastOrDefault(filter);
        }
        public List<Blog> LastBlog(Expression<Func<Blog, bool>> filter)
        {
            return Context.Blogs.Where(filter)
                                     .OrderByDescending(x => x.CreateTime)
                                     .Take(DefaultConstantValue.LASTBLOG)
                                     .ToList();
        }

        public void IncreesCommentCounta(int id)
        {
            Context.Blogs.Find(id).CommentCounta++;
            Context.SaveChanges();
        }

    }

}


