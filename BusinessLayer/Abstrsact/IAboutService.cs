using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer;
using DTOLayer.AboutDTO;

namespace BusinessLayer.Abstrsact
{
    public interface IAboutService
    {
        IDataResult<List<AboutDTOs>> TGetAll();
        IDataResult<List<AboutGetActivDTOs>> TGetActiv();
        IDataResult<AboutDTOs> TGetById(int id);
        IResult TAdd(AboutCreate entity);
        IResult TUpdate(AboutDTOs entity);
        IResult TDelete(AboutDTOs entity);
        IResult THardDelete(AboutDTOs entity);
    }
}
