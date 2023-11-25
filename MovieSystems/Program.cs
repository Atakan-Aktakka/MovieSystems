using Microsoft.EntityFrameworkCore;
using MovieSystems.Context;
using MovieSystems.Repositories.Abstract;
using MovieSystems.Repositories.Concrete;
using MovieSystems.Services.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BaseDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<FilmService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
