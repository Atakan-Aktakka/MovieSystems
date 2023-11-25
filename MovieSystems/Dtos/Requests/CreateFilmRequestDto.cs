using MovieSystems.Dtos.Responses;

namespace MovieSystems.Dtos.Requests
{
    public class CreateFilmRequestDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Category { get; set; }
        public List<ActorDto> Actors { get; set; }
        public List<FilmCrewMemberDto> Crew { get; set; }
        public string Publisher { get; set; }
        public int Rating { get; set; }
    }
}
