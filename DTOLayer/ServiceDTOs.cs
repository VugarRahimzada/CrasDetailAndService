using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer
{
    public class ServiceDTOs
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        //Şəklin tutma tipini müəyyən et
        public string ImageUrl { get; set; }
    }
}
