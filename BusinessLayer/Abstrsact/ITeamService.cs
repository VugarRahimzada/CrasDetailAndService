using CoreLayer.Results.Concrete;
using DTOLayer;

namespace BusinessLayer.Abstrsact
{
    public interface ITeamService
    {
        DataResult<List<TeamDTOs>> TGetAll();
        DataResult<List<TeamDTOs>> TGetActiv();
        DataResult<TeamDTOs> TGetById(int id);
        Result TAdd(TeamDTOs entity);
        Result TUpdate(TeamDTOs entity);
        Result TDelete(TeamDTOs entity);
        Result THardDelete(TeamDTOs entity);
    }
}
