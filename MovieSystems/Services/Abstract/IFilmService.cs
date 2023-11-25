using MovieSystems.Dtos.Requests;
using MovieSystems.Dtos.Responses;
using MovieSystems.Models.Return;

namespace MovieSystems.Services.Abstract
{
    public interface IFilmService
    {
        ApiResponse<List<FilmDto>> GetList();
        ApiResponse<List<FilmDto>> GetById(int id);
        ApiResponse<List<FilmDto>> Add(CreateFilmRequestDto filmRequestDto);
        ApiResponse<List<FilmDto>> Update(UpdateFilmRequestDto filmRequestDto);
        ApiResponse<List<FilmDto>> Delete(int id);
    }
}
