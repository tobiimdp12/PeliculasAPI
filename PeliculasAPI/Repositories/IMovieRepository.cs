using PeliculasAPI.Models;

namespace PeliculasAPI.Repositories
{
    public interface IMovieRepository
    {
        public IEnumerable<Movies> GetAllMovies();
     

        //id
        public Movies getMovieById(int id);
        
   
        public IEnumerable<Movies> getByTitle(string title);
    

        public IEnumerable<Movies> getByGen(int genre);
     


        public IEnumerable<Movies> sortMovies();



        public Movies AddMovie(Movies movie);
     
        public Movies UpdateMovie(Movies movieUpdated);
 
        public bool DeleteMovie(int id);



    }
}
