using CoreLayer.Results.Abstract;
using DTOLayer.TeamDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using IResult = CoreLayer.Results.Abstract;
namespace BusinessLayer.Abstrsact
{
    public interface ITeamService
    {
        IDataResult<List<TeamDTOs>> TGetAll();
        IDataResult<List<TeamActiveDTOs>> TGetActiv();
        IDataResult<TeamDTOs> TGetById(int id);
        IDataResult<List<TeamActiveDTOs>> TGetTeamHomePage();
        IResult.IResult TAdd(TeamCreateDTOs entity, IFormFile photoUrl,out List<ValidationFailure> errors);
        IResult.IResult TUpdate(TeamDTOs entity, IFormFile photoUrl, out List<ValidationFailure> errors);
        IResult.IResult TDelete(TeamDTOs entity);
        IResult.IResult THardDelete(TeamDTOs entity);
        IDataResult<int> TCount();
    }
}
