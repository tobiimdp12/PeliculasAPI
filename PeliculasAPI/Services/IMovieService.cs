using PeliculasAPI.DTOs;
using PeliculasAPI.Models;

namespace PeliculasAPI.Services
{
    public interface IMovieService
    {

        public IEnumerable<Movies> GetAllMovies();
     


        public IEnumerable<MovieDTO> GetMovieTitleImageDate();


        public Movies GetById(int Id);


        public IEnumerable<Movies> getByTitle(string title);


        public IEnumerable<Movies> getByGen(int genre);
 


        public IEnumerable<Movies> sortMovies(string order);



        public Movies AddMovie(MovieCreationDTO movieDTO);



        public Movies UpdateMovie(int id, MovieCreationDTO movieUpdated);
 
        public bool DeleteMovie(int id);
  
    }
}
