using CoreLayer.Entity;

namespace EntityLayer.Models
{
    public class Pricing : BaseEntity
    {
        public Pricing()
        {
            PriceDescription = new HashSet<PriceDescription>();
            Order = new HashSet<Order>();
        }
        public string Title { get; set; }
        public double Price { get; set; }
        public ICollection<PriceDescription> PriceDescription { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
