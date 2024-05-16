using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer.TeamDTO;

namespace BusinessLayer.Abstrsact
{
    public interface ITeamService
    {
        IDataResult<List<TeamDTOs>> TGetAll();
        IDataResult<List<TeamActiveDTOs>> TGetActiv();
        IDataResult<TeamDTOs> TGetById(int id);
        IResult TAdd(TeamCreateDTOs entity);
        IResult TUpdate(TeamDTOs entity);
        IResult TDelete(TeamDTOs entity);
        IResult THardDelete(TeamDTOs entity);
    }
}
