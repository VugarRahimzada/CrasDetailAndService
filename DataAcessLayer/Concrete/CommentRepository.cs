using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class CommentRepository : GenericRepository<Comment, AppDbContext>, ICommentRepository
    {
        private readonly AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Comment> GetCommentsById(Expression<Func<Comment,bool>>filt)
        {
            return _appDbContext.Comments.Where(filt).Where(x=>x.Delete==0).ToList();
        }
    }

}


