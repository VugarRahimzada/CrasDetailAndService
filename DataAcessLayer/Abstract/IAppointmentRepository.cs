using CoreLayer.DataAccess.Abstract;
using EntityLayer.Models;

namespace DataAccessLayer.Abstract
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
    }
}
