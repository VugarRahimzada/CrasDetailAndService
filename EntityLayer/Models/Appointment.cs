using CoreLayer.Entity;

namespace EntityLayer.Models
{
    public class Appointment:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VehicelType { get; set; }
        public string Message { get; set; }
        public DateTime SelectDate { get; set; }
    }
}
