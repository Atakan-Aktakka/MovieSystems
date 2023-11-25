using System.ComponentModel.DataAnnotations;

namespace MovieSystems.Models
{
    public class FilmCrewMember
    {
        [Key]
        public int CrewMemberId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
