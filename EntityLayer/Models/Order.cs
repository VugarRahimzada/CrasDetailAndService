using CoreLayer.Entity;

namespace EntityLayer.Models
{
    public class Order :BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string LicensePlate { get; set; }
        public DateTime Deadline { get; set; } = DateTime.Now.AddMonths(6);
        public int PricingId { get; set; }
        public virtual Pricing Pricing { get; set; }
    }
}
