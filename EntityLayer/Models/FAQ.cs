using CoreLayer.Entity;

namespace EntityLayer.Models
{
    public class FAQ :BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
