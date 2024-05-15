using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.OrderDTO
{
    public class OrderDTOs
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string LicensePlate { get; set; }
        public DateTime Deadline { get; set; } = DateTime.Now.AddMonths(6);
        public int PricingId { get; set; }
    }
}
