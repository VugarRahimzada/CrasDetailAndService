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
        public int CommentCounta { get; set; } = 0;
        //Şəklin tutma tipini müəyyən et
        public string ImageUrl { get; set; }
    }
}
