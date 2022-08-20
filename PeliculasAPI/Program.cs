using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Data;
using PeliculasAPI.Repositories;
using PeliculasAPI.Services;
using PeliculasAPI.Utils;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Add repositories

builder.Services.AddScoped<ICharacterRepository,CharacterRepository>();
builder.Services.AddScoped<IMovieRepository,MovieRepository>();

//Add services
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IMovieService, MovieService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
