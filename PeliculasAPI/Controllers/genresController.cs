using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

    [AllowAnonymous]
    public class genresController : ControllerBase
    {
        private readonly DataContext _context;

        public genresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre()
        {
          if (_context.Genre == null)
          {
              return NotFound();
          }
            return await _context.Genre.ToListAsync();
        }

        // GET: api/genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> Getgenre(int id)
        {
          if (_context.Genre == null)
          {
              return NotFound();
          }
            var genre = await _context.Genre.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // POST: api/genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> Postgenre(GenreDTO genreDTO)
        {
            if (_context.Genre == null)
            {
                return Problem("Entity set 'DataContext.Genre'  is null.");
            }

            Genre genre = new Genre()
            {
                Name = genreDTO.Name,
            };

            _context.Genre.Add(genre);
            await _context.SaveChangesAsync();

            return Ok(genre);
        }

        // PUT: api/genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgenre(int id, GenreDTO genreDTO)
        {
  

            Genre genre = await _context.Genre.FindAsync(id);

            genre.Name = genreDTO.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!genreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

 

        // DELETE: api/genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegenre(int id)
        {
            if (_context.Genre == null)
            {
                return NotFound();
            }
            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool genreExists(int id)
        {
            return (_context.Genre?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
