﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.TeamDTO
{
    public class TeamCreateDTOs
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public bool isHomePage { get; set; } = false;
        [NotMapped]
        public IFormFile photoUrl { get; set; }
    }
}
