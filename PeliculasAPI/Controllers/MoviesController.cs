using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Data;
using PeliculasAPI.DTOs;
using PeliculasAPI.Models;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MoviesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movies>>> GetMovies()
        {
          if (_context.Movies == null)
          {
              return NotFound();
          }
            return await _context.Movies.Include(x=>x.Genre).ToListAsync();
        }
        [HttpGet("/movies")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesImageTitleDate()
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movies = _context.Movies;//Repository
            var moviesToReturn = _mapper.Map<IEnumerable<MovieDTO>>(movies);

            return Ok(moviesToReturn);
        }


        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movies>> GetMovies(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movie = _context.Movies.Where(c => c.Id == id).Include(p=>p.Genre);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet("/title")]
        public async Task<ActionResult<IEnumerable<Movies>>> GetMoviesByTitle([FromQuery] string Title)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }

            var movies = _context.Movies.Where(u => u.Title.Contains(Title)).Include(m => m.Genre);


            return Ok(movies);
        }

        [HttpGet("/genre")]
        public async Task<ActionResult<IEnumerable<Movies>>> GetMoviesByGen([FromQuery] int genreId)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }

            var movies = _context.Movies.Where(u => u.genreId == genreId).Include(m => m.Genre);


            return Ok(movies);
        }

        [HttpGet("/sort")]
        public async Task<ActionResult<IEnumerable<Movies>>> SortMovies([FromQuery] string order)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            List<Movies> movies = _context.Movies.OrderBy(o => o.Calification).Include(g=>g.Genre).ToList();
            if (order.ToString().ToUpper() == "DESC")
            {
               movies.Reverse();
            }

            return Ok(movies);
        }


        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movies>> PostMovies(MovieCreationDTO moviesDTO)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'DataContext.Movies'  is null.");
            }
            Movies movie = _mapper.Map<Movies>(moviesDTO);
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return Ok(movie);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovies(int id, MovieCreationDTO moviesDTO)
        {
            Movies movie = _context.Movies.Find(id);

            if (movie == null) return NotFound();


            movie = _mapper.Map(moviesDTO, movie);//para que el id no se transforme en 0

            await _context.SaveChangesAsync();
            return Ok(movie);

        }

        

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovies(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoviesExists(int id)
        {
            return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
