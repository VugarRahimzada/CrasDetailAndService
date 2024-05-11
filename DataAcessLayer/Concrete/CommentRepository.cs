using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class CommentRepository : GenericRepository<Comment, AppDbContext>, ICommentRepository
    {
        AppDbContext appdb = new AppDbContext();

        public List<Comment> GetCommentsById(Expression<Func<Comment,bool>>filt)
        {
            return appdb.Comments.Where(filt).ToList();
        }
    }

}


