using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Contact :BaseEntity
    {
        public string Email { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
    }
}
