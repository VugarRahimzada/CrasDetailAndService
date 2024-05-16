using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.PriceDescriptionDTO
{
    public class PriceDescriptionDTOs
    {
        public string Description { get; set; }
        public int PricingId { get; set; }
        public virtual Pricing Pricing { get; set; }
        public int Id { get; set; }
        public int Delete { get; set; }
    }
}
