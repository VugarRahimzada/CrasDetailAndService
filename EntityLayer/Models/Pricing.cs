using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Pricing : BaseEntity
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public List<PriceDescription> PriceDescription { get; set; }
    }
}
