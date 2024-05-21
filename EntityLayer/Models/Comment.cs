using CoreLayer.Entity;

namespace EntityLayer.Models
{
    public class Comment :BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
