using CoreLayer.DataAccess.Abstract;
using EntityLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Blog LastOrDefault(Expression<Func<Blog, bool>> filter);
        List<Blog> LastBlog(Expression<Func<Blog, bool>> filter);
        void IncreesCommentCounta(int id);
        void DecreaseCommentCounta(int id);
    }

}
