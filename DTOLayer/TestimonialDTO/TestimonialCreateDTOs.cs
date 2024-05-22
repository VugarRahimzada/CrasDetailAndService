using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.TestimonialDTO
{
    public class TestimonialCreateDTOs
    {
        public string Name { get; set; }
        public string Suranme { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
        public bool isHomePage { get; set; } = false;
        public IFormFile photoUrl { get; set; }

    }
}
