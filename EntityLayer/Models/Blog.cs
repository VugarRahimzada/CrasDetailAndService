using CoreLayer.Entity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public IFormFile photoUrl { get; set; }
        public ICollection<Comment> Comment { get; set; }
    }
}
