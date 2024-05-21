using CoreLayer.Entity;

namespace EntityLayer.Models
{
    public class Blog : BaseEntity
    {
        public Blog()
        {
            Comment = new HashSet<Comment>();
        }
        public string Title { get; set; }
        public string Text { get; set; }
        public int CommentCounta {  get; set; } = 0;
        public string ImageUrl { get; set; }
        public ICollection<Comment> Comment { get; set; }
    }
}
