using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class CommentRepository : GenericRepository<Comment, AppDbContext>, ICommentRepository
    {
        AppDbContext Context = new AppDbContext();
        //public CommentRepository(AppDbContext context) : base(context)
        //{
        //}

        public List<Comment> GetCommentsById(Expression<Func<Comment,bool>>filt)
        {
            return Context.Comments.Where(filt).ToList();
        }
    }

}


