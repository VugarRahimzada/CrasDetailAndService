using CoreLayer.Results.Abstract;
using DTOLayer.AppointmentDTO;

namespace BusinessLayer.Abstrsact
{
    public interface IAppointmentService
    {
        IDataResult<List<AppointmentDTOs>> TGetAll();
        IDataResult<List<AppointmentDTOs>> TGetActiv();
        IDataResult<AppointmentDTOs> TGetById(int id);
        IResult TAdd(AppointmentDTOs entity);
        IResult TUpdate(AppointmentDTOs entity);
        IResult TDelete(AppointmentDTOs entity);
        IResult THardDelete(AppointmentDTOs entity);
    }
}
