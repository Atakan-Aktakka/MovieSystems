using Microsoft.EntityFrameworkCore;
using MovieSystems.Models;
using System.Reflection;

namespace MovieSystems.Context
{
    public class BaseDbContext:DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=FilmDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Film> Films { get; set; }

        public DbSet<FilmCrewMember> FilmCrewMembers { get; set; }

        public DbSet<Publisher> Publishers { get; set; }


    }
}

