﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.BlogDTO
{
    public class BlogGetActivDTOs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int CommentCounta { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateTime { get; set; } 
    }
}
