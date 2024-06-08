using CoreLayer.Results.Abstract;
using DTOLayer.AboutDTO;
using FluentValidation.Results;

namespace BusinessLayer.Abstrsact
{
    public interface IAboutService
    {
        IDataResult<List<AboutDTOs>> TGetAll();
        IDataResult<List<AboutGetActivDTOs>> TGetActiv();
        IDataResult<AboutDTOs> TGetById(int id);
        IResult TAdd(AboutCreateDTOs entity,out List<ValidationFailure> errors);
        IResult TUpdate(AboutUpdateDTOs entity, out List<ValidationFailure> errors);
        IResult TDelete(AboutDTOs entity);
    }
}
