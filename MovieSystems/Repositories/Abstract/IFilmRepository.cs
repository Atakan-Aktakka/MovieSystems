using MovieSystems.Models;

namespace MovieSystems.Repositories.Abstract
{
    public interface IFilmRepository
    {
        void Add(Film film);
        void Update(Film film);
        void Delete(int id);
        Film GetById(int id);
        List<Film> GetAll();
    }
}
