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

        public List<Comment> GetCommentsById(Expression<Func<Comment, bool>> filter)
        {
            return _appDbContext.Comments
                .Where(filter)
                .Where(x => x.Delete == 0)
                .ToList();
        }

        public List<Comment> GetCommentsByIdAdmin(Expression<Func<Comment, bool>> filter)
        {
            return _appDbContext.Comments
                .Where(filter)
                .ToList();
        }
    }
}



