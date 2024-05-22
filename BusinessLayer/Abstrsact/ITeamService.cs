using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer.TeamDTO;
using EntityLayer.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace BusinessLayer.Abstrsact
{
    public interface ITeamService
    {
        IDataResult<List<TeamDTOs>> TGetAll();
        IDataResult<List<TeamActiveDTOs>> TGetActiv();
        IDataResult<TeamDTOs> TGetById(int id);
        IDataResult<List<TeamActiveDTOs>> TGetTeamHomePage();
        CoreLayer.Results.Abstract.IResult TAdd(TeamCreateDTOs entity, IFormFile photoUrl,out List<ValidationFailure> errors);
        CoreLayer.Results.Abstract.IResult TUpdate(TeamDTOs entity, IFormFile photoUrl, out List<ValidationFailure> errors);
        CoreLayer.Results.Abstract.IResult TDelete(TeamDTOs entity);
        CoreLayer.Results.Abstract.IResult THardDelete(TeamDTOs entity);
        IDataResult<int> TCount();
    }
}
