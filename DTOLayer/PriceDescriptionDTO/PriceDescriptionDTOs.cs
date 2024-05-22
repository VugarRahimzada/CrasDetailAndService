using EntityLayer.Models;

namespace DTOLayer.PriceDescriptionDTO
{
    public class PriceDescriptionDTOs
    {
        public int Id { get; set; }
        public int Delete { get; set; }
        public string Description { get; set; }
        public int PricingId { get; set; }
        public virtual Pricing Pricing { get; set; }
    }
}
