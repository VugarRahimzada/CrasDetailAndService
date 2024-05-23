using CoreLayer.DataAccess.Abstract;
using EntityLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        List<Team> GetTeamHomePage(Expression<Func<Team,bool>>function);
        bool Any(Expression<Func<Order, bool>> filter);
    }

}
