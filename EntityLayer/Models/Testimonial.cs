using CoreLayer.Entity;

namespace EntityLayer.Models
{
    public class Testimonial :BaseEntity
    {
        public string Name { get; set; }
        public string Suranme { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
    }
}
