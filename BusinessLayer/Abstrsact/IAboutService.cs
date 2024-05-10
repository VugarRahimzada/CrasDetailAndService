using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer;

namespace BusinessLayer.Abstrsact
{
    public interface IAboutService
    {
        IDataResult<List<AboutDTOs>> TGetAll();
        IDataResult<List<AboutDTOs>> TGetActiv();
        IDataResult<AboutDTOs> TGetById(int id);
        IResult TAdd(AboutDTOs entity);
        IResult TUpdate(AboutDTOs entity);
        IResult TDelete(AboutDTOs entity);
        IResult THardDelete(AboutDTOs entity);
    }
}
