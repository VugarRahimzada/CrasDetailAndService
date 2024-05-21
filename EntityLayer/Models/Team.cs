using CoreLayer.Entity;

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
    }
}
