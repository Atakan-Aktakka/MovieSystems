using AutoMapper;
using MovieSystems.Dtos.Requests;
using MovieSystems.Dtos.Responses;
using MovieSystems.Exceptions;
using MovieSystems.Models;
using MovieSystems.Models.Return;
using MovieSystems.Repositories.Abstract;
using MovieSystems.Services.Abstract;

namespace MovieSystems.Services.Concrete
{
    public class FilmService : IFilmService
    {
        public IFilmRepository _filmRepository;
        public IMapper _mapper;
        public ApiResponse<List<FilmDto>> Add(CreateFilmRequestDto filmRequestDto)
        {
            Film film = _mapper.Map<Film>(filmRequestDto);

            try
            {
                if (_filmRepository.GetById(film.FilmId) != null)
                {
                    return new ApiResponse<List<FilmDto>>()
                    {
                        Data = null,
                        Message = "Film sistemde bulunuyor",
                        StatusCode = System.Net.HttpStatusCode.Conflict
                    };
                }
                else
                {
                    _filmRepository.Add(film);
                    FilmDto filmDto = _mapper.Map<FilmDto>(film);
                    return new ApiResponse<List<FilmDto>>()
                    {
                        Data = new List<FilmDto> { filmDto },
                        Message = "Ekleme işlemi başarılı",
                        StatusCode = System.Net.HttpStatusCode.Created
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<FilmDto>>()
                {
                    Data = null,
                    Message = "Bir hata oluştu",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public ApiResponse<List<FilmDto>> Delete(int id)
        {
            try
            {
                var film = _filmRepository.GetById(id);
                _filmRepository.Delete(id);
                var response = _mapper.Map<FilmDto>(film);
                return new ApiResponse<List<FilmDto>>()
                {
                    Data = new List<FilmDto> { response }, // Wrap the single item in a list
                    Message = $"Id si : {id} olan film silindi",
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<FilmDto>>()
                {
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }
        }


        public ApiResponse<List<FilmDto>> GetById(int id)
        {
            try
            {
                var film = _filmRepository.GetById(id);
                var response = _mapper.Map<FilmDto>(film);

                return new ApiResponse<List<FilmDto>>()
                {
                    Data = new List<FilmDto> { response }, // Wrap the single item in a list
                    Message = $"The given Id field is found ({id})",
                    StatusCode = System.Net.HttpStatusCode.Found
                };
            }
            catch (NotFoundException ex)
            {
                return new ApiResponse<List<FilmDto>>()
                {
                    Data = null,
                    Message = $"The given Id field ({id}) does not exist",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }
        }


        public ApiResponse<List<FilmDto>> GetList()
        {
            var list = _filmRepository.GetAll();
            List<FilmDto> response = _mapper.Map<List<FilmDto>>(list);

            return new ApiResponse<List<FilmDto>>()
            {
                Data = response,
                Message = "Oyuncular listelendi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }

        public ApiResponse<List<FilmDto>> Update(UpdateFilmRequestDto filmRequestDto)
        {
            try
            {
                var newFilm = _mapper.Map<Film>(filmRequestDto);
                _filmRepository.Update(newFilm);
                var response = _mapper.Map<FilmDto>(newFilm);

                return new ApiResponse<List<FilmDto>>()
                {
                    Data = new List<FilmDto> { response }, // Wrap the single item in a list
                    Message = $"The given Id field ({filmRequestDto.FilmId}) is updated",
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (NotFoundException ex)
            {
                return new ApiResponse<List<FilmDto>>()
                {
                    Data = null,
                    Message = $"The given Id field ({filmRequestDto.FilmId}) does not exist",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }
        }

    }
}
