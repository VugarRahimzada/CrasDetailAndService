using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer;

namespace BusinessLayer.Abstrsact
{
    public interface ITeamService
    {
        IDataResult<List<TeamDTOs>> TGetAll();
        IDataResult<List<TeamDTOs>> TGetActiv();
        IDataResult<TeamDTOs> TGetById(int id);
        IResult TAdd(TeamDTOs entity);
        IResult TUpdate(TeamDTOs entity);
        IResult TDelete(TeamDTOs entity);
        IResult THardDelete(TeamDTOs entity);
    }
}
