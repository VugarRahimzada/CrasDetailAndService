using CoreLayer.Entity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Models
{
    public class Testimonial :BaseEntity
    {
        public string Name { get; set; }
        public string Suranme { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile photoUrl { get; set; }
    }
}
