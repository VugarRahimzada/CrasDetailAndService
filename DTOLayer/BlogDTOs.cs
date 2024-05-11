using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer
{
    public class BlogDTOs
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int CommentCounta { get; set; }
        public string ImageUrl { get; set; }
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public List<Comment> Comment { get; set; }
    }
}
