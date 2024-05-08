using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class PriceDescription : BaseEntity
    {
        public string Description { get; set; }
        public int PricingId { get; set; }
        public virtual Pricing Pricing { get; set; }
    }
}
