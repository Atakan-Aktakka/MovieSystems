using Microsoft.EntityFrameworkCore;
using MovieSystems.Context;
using MovieSystems.Exceptions;
using MovieSystems.Models;
using MovieSystems.Repositories.Abstract;

namespace MovieSystems.Repositories.Concrete
{
    public class FilmRepository : IFilmRepository
    {
        private readonly BaseDbContext _context;

        public FilmRepository(BaseDbContext context)
        {
            _context = context;
        }
        public void Add(Film film)
        {
            _context.Films.Add(film);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var film = _context.Films.Find(id);
            if (film == null)
            {
                throw new NotFoundException(id);
            }
            _context.Films.Remove(film);
            _context.SaveChanges();
        }

        public List<Film> GetAll()
        {
            return _context.Films
                .Include(f => f.Publisher)
                .Include(f => f.Actors)
                .Include(f => f.Crew)
                .ToList();
        }

        public Film GetById(int id)
        {
            var film = _context.Films.Find(id);
            if (film == null)
            {
                throw new NotFoundException(id);
            }
            return film;
        }

        public void Update(Film film)
        {
            var filmtoUpdate = _context.Films.Find(film.FilmId);
            if (filmtoUpdate == null)
            {
                throw new NotFoundException(film.FilmId);
            }
            _context.Films.Update(film);
            _context.SaveChanges();
        }
    }
}
