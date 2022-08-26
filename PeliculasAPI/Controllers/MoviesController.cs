using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Data;
using PeliculasAPI.DTOs;
using PeliculasAPI.Models;
using PeliculasAPI.Services;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AppUser")]

    public class MoviesController : ControllerBase
    {
     
        private readonly IMovieService _movieService;

        public MoviesController( IMovieService movieService)
        {
           _movieService = movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<Movies>> GetMovies()
        {

            return Ok(_movieService.GetAllMovies());
        }
        [HttpGet("/movies")]
        public ActionResult<IEnumerable<MovieDTO>> GetMoviesImageTitleDate()
        {

            var moviesToReturn = _movieService.GetMovieTitleImageDate();

            return Ok(moviesToReturn);
        }


        // GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<Movies> GetMovies(int id)
        {

            var movie = _movieService.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet("/title")]
        public ActionResult<IEnumerable<Movies>> GetMoviesByTitle([FromQuery] string Title)
        {


            var movies = _movieService.getByTitle(Title);


            return Ok(movies);
        }

        [HttpGet("/genre")]
        public ActionResult<IEnumerable<Movies>> GetMoviesByGen([FromQuery] int genreId)
        {

            var movies = _movieService.getByGen(genreId);

            return Ok(movies);
        }

        [HttpGet("/sort")]
        public ActionResult<IEnumerable<Movies>> SortMovies([FromQuery] string order)
        {

            var movies = _movieService.sortMovies(order);

            if (movies == null) return BadRequest();
            return Ok(movies);
        }


        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Movies> PostMovies(MovieCreationDTO moviesDTO)
        {

            Movies movie = _movieService.AddMovie(moviesDTO);

            if (movie == null) return BadRequest();

            return Ok(movie);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutMovies(int id, MovieCreationDTO moviesDTO)
        {
            Movies movie = _movieService.UpdateMovie(id, moviesDTO);

            if (movie == null) return NotFound();

            return Ok(movie);

        }



        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovies(int id)
        {

            bool result = _movieService.DeleteMovie(id);

            if (result == false) return BadRequest("Not found");

            return Ok("Deleted Successfully");
        }


    }
}
