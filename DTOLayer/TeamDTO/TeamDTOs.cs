namespace DTOLayer.TeamDTO

{
    public class TeamDTOs
    {
        public int Id { get; set; }
        public int Delete { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public bool isHomePage { get; set; } = false;
    }
}
