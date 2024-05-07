using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class About: BaseEntity
    {
        public string Misson { get; set; }
        public string Vision { get; set; }
        public string History { get; set; }
    }
}
