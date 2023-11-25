using MovieSystems.Dtos.Responses;
using MovieSystems.Models;
using AutoMapper;
using MovieSystems.Dtos.Requests;

namespace MovieSystems.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateFilmRequestDto, Film>();
            CreateMap<UpdateFilmRequestDto, Film>();
            CreateMap<Film, FilmDto>();
            CreateMap<FilmCrewMember, FilmCrewMemberDto>();
            CreateMap<Publisher, PublisherDto>();
            CreateMap<Actor, ActorDto>();
        }

    }
}

