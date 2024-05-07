using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;

namespace DataAccessLayer.Concrete
{
    public class AppointmentRepository : GenericRepository<Appointment, AppDbContext>, IAppointmentRepository
    {

    }

}


