﻿using CoreLayer.Entity;

namespace EntityLayer.Models
{
    public class Service :BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool isHomePage { get; set; } = false;
    }
}
