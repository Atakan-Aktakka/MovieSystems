namespace MovieSystems.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Category { get; set; }
        public List<Actor> Actors { get; set; }
        public List<FilmCrewMember> Crew { get; set; }
        public string Publisher { get; set; }
        public int Rating { get; set; }
    }
}
