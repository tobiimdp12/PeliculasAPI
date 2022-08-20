using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Data;
using PeliculasAPI.Models;

namespace PeliculasAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;

        }

        public IEnumerable<Movies> GetAllMovies()
        {
            return _context.Movies.Include(x => x.Genre).ToList();
        }

        //id
        public Movies getMovieById(int id)
        {
            return _context.Movies.Where(m=>m.Id==id).Include(g=>g.Genre).FirstOrDefault();
        }

        public IEnumerable<Movies> getByTitle(string title)
        {
            var movies = _context.Movies.Where(u => u.Title == title).Include(m => m.Genre);
            return movies;
        }

        public IEnumerable<Movies> getByGen(int genre)
        {
            var movies = _context.Movies.Where(u => u.genreId == genre).Include(m => m.Genre);
            return movies;
        }


        public IEnumerable<Movies> sortMovies()
        {
            List<Movies> movies = _context.Movies.OrderBy(o => o.Calification).Include(g => g.Genre).ToList();
            
            

            return movies;
        }


        public Movies AddMovie(Movies movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }

        public Movies UpdateMovie(Movies movieUpdated)
        {
            try
            {

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return movieUpdated;
        }
        public bool DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null) return false;
            
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return true;
        }
    }
}
