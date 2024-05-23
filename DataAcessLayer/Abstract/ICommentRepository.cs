using CoreLayer.DataAccess.Abstract;
using EntityLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        List<Comment> GetCommentsById(Expression<Func<Comment, bool>> filt);
        List<Comment> GetCommentsByIdAdmin(Expression<Func<Comment, bool>> filt);
    }  
}
