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
    public class CharactersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CharactersController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }
            return await _context.Characters.Include(m => m.Movies).ThenInclude(g=>g.Genre).ToListAsync();
        }

        // GET: api/Characters
        [HttpGet("/characters")]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharactersImageName()
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }
            var characters = _context.Characters;//Repository
            var charactersToReturn = _mapper.Map<IEnumerable<CharacterDTO>>(characters);

            return Ok(charactersToReturn);
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }
            var character = _context.Characters.Where(c => c.Id == id).Include(c=>c.Movies).ThenInclude(m=>m.Genre);
            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }


        [HttpGet("/name")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersByName([FromQuery]string name)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }

            var characters = _context.Characters.Where(u => u.Name.Contains(name)).Include(m=>m.Movies).ThenInclude(g=>g.Genre);


            return Ok(characters);
        }

        [HttpGet("/age")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersByAge([FromQuery] int age)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }

            var characters = _context.Characters.Where(u => u.Age == age).Include(m => m.Movies).ThenInclude(g => g.Genre);


            return Ok(characters);
        }

        [HttpGet("/movie")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersByMovie([FromQuery] int movieId)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }
            Movies movie= _context.Movies.Find(movieId);

            if (movie == null) return NotFound();

            var characters = _context.Characters.Where(c=>c.Movies.Contains(movie)).Include(m => m.Movies).ThenInclude(g => g.Genre);


            return Ok(characters.Include(c=>c.Movies).ThenInclude(m=>m.Genre));
        }




        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreationDTO characterDTO)
        {
            if (_context.Characters == null)
            {
                return Problem("Entity set 'DataContext.Characters'  is null.");
            }
            Character character = _mapper.Map<Character>(characterDTO);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return Ok(character);
        }

        [HttpPost("assignCharacter")]
        public async Task<ActionResult<Character>> AssignCharactertoMovie(CharacterMovies characterMovies)
        {
            //get the character
            var character = await _context.Characters
                .Where(c => c.Id == characterMovies.CharacterId)
                .Include(c => c.Movies)
                .FirstOrDefaultAsync();

            if (character == null)
                return NotFound();

            //get skill
            var movie = await _context.Movies.FindAsync(characterMovies.MovieId);
            if (movie == null)
                return NotFound();

            character.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return character;
        }




        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterCreationDTO characterDTO)
        {


            Character character = _context.Characters.Find(id);

            if (character == null) return NotFound();


            character = _mapper.Map(characterDTO, character);//para que el id no se transforme en 0

            await _context.SaveChangesAsync();
            return Ok(character);


       
        }


        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
