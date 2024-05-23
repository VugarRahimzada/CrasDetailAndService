using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class TeamRepository : GenericRepository<Team, AppDbContext>, ITeamRepository
    {
        private readonly AppDbContext _appDbContext;

        public TeamRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Team> GetTeamHomePage(Expression<Func<Team, bool>> function)
        {
            var value = _appDbContext.Teams.Where(function).Where(x => x.Delete == 0).ToList();
            return value;
        }
        public bool Any(Expression<Func<Order, bool>> filter)
        {
            var result = _appDbContext.Orders.Any(filter);
            return result;
        }
    }

}


