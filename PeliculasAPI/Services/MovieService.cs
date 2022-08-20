using AutoMapper;
using PeliculasAPI.DTOs;
using PeliculasAPI.Models;
using PeliculasAPI.Repositories;

namespace PeliculasAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }


        public IEnumerable<Movies> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }


        public IEnumerable<MovieDTO> GetMovieTitleImageDate()
        {
            var movies = _movieRepository.GetAllMovies();

            var moviesToReturn = _mapper.Map<IEnumerable<MovieDTO>>(movies);

            return moviesToReturn;
        }

        public Movies GetById(int Id)
        {
            var movie = _movieRepository.getMovieById(Id);


            return movie;
        }

        public IEnumerable<Movies> getByTitle(string title)
        {
            var movies = _movieRepository.getByTitle(title);
            return movies;
        }

        public IEnumerable<Movies> getByGen(int genre)
        {
            var movies = _movieRepository.getByGen(genre);
            return movies;
        }


        public IEnumerable<Movies> sortMovies(string order)
        {
            List<Movies> movies = (List<Movies>)_movieRepository.sortMovies();

            if (order.ToString().ToUpper() == "DESC")
            {
                movies.Reverse();
            }else if (order.ToString().ToUpper() =="ASC")
            {
               movies = (List<Movies>)_movieRepository.sortMovies();
            }else
            {
                movies = null;
            }

            return movies;
        }


        public Movies AddMovie(MovieCreationDTO movieDTO)
        {
         
            Movies movie = _mapper.Map<Movies>(movieDTO);

            var movies = getByTitle(movieDTO.Title);
           
            if (movies.Any())
            {
                return null;
            }

     
            _movieRepository.AddMovie(movie);
            return movie;
        }

     
        public Movies UpdateMovie(int id, MovieCreationDTO movieUpdated)
        {
            if (_movieRepository.getMovieById(id) == null)
            {
                return null;
            }

            Movies movie = _movieRepository.getMovieById(id);

            movie = _mapper.Map(movieUpdated, movie);//para que el id no se transforme en 0

            movie = _movieRepository.UpdateMovie(movie);
            return movie;
        }
        public bool DeleteMovie(int id)
        {

            return _movieRepository.DeleteMovie(id);
        }

    }
}
