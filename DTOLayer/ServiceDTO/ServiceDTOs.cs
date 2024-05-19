using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.ServiceDTO
{
    public class ServiceDTOs
    {
        public int Id { get; set; }
        public int Delete { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool isHomePage { get; set; } = false;
    }
}
