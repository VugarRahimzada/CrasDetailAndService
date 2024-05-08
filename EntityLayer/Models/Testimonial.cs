using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Testimonial :BaseEntity
    {
        public string Name { get; set; }
        public string Suranme { get; set; }
        public string Message { get; set; }
    }
}
