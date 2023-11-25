namespace MovieSystems.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Film> FilmsPublished { get; set; }
    }
}
