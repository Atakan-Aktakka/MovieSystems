namespace MovieSystems.Dtos.Responses
{
    public class PublisherDto
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<FilmDto> FilmsPublished { get; set; }
    }
}
