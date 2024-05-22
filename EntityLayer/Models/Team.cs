using CoreLayer.Entity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Models
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public bool isHomePage { get; set; } = false;

        [NotMapped]
        public IFormFile photoUrl { get; set;}

    }
}
