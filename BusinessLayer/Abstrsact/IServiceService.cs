using CoreLayer.Results.Abstract;
using DTOLayer.ServiceDTO;
using FluentValidation.Results;

namespace BusinessLayer.Abstrsact
{
    public interface IServiceService
    {
        IDataResult<List<ServiceDTOs>> TGetAll();
        IDataResult<List<ServiceActivDTOs>> TGetActiv();
        IDataResult<ServiceDTOs> TGetById(int id);
        IDataResult<List<ServiceActivDTOs>> TGetServiceHomePage();
        IResult TAdd(ServiceCreateDTOs entity, out List<ValidationFailure> errors);
        IResult TUpdate(ServiceDTOs entity, out List<ValidationFailure> errors);
        IResult TDelete(ServiceDTOs entity);
        IResult THardDelete(ServiceDTOs entity);
    }
}
