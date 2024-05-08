using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int CommentCounta {  get; set; } = 0;
        public string ImageUrl { get; set; }
        public List<Comment> Comment { get; set; }
    }
}
