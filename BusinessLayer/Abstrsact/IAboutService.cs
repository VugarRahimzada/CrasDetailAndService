using CoreLayer.Results.Concrete;
using DTOLayer;

namespace BusinessLayer.Abstrsact
{
    public interface IAboutService
    {
        DataResult<List<AboutDTOs>> TGetAll();
        DataResult<List<AboutDTOs>> TGetActiv();
        DataResult<AboutDTOs> TGetById(int id);
        Result TAdd(AboutDTOs entity);
        Result TUpdate(AboutDTOs entity);
        Result TDelete(AboutDTOs entity);
        Result THardDelete(AboutDTOs entity);
    }
}
