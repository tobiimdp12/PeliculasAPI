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
using PeliculasAPI.Repositories;
using PeliculasAPI.Services;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {

        private readonly ICharacterService _characterService;
        private readonly IMovieService _movieService;


        public CharactersController(ICharacterService characterService, IMovieService movieService)
        {

            _characterService = characterService;
            _movieService = movieService;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {

            return Ok(_characterService.GetAllCharacters());
        }

        // GET: api/Characters
        [HttpGet("/characters")]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharactersImageName()
        {

            var charactersToReturn = _characterService.GetCharactersImageName();

            return Ok(charactersToReturn);
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {

            var character = _characterService.GetById(id);

            if (character == null) return NotFound();

            return Ok(character);
        }


        [HttpGet("/name")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersByName([FromQuery] string name)
        {

            var characters = _characterService.getByName(name);

            bool isEmpty = !characters.Any();

            if (isEmpty) return BadRequest();

            return Ok(characters);
        }

        [HttpGet("/age")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersByAge([FromQuery] int age)
        {
            var characters = _characterService.getByAge(age);

            bool isEmpty = !characters.Any();

            if (isEmpty) return BadRequest();

            return Ok(characters);
        }

        [HttpGet("/movie")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersByMovie([FromQuery] int movieId)
        {

            Movies movie = _movieService.GetById(movieId);

            if (movie == null) return NotFound();

            var characters = _characterService.getByMovies(movieId);

            bool isEmpty = !characters.Any();
            
            if (isEmpty) return BadRequest();

            return Ok(characters);
        }


        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreationDTO characterDTO)
        {
            Character character = _characterService.AddCharacter(characterDTO);

            if (character == null) return BadRequest();

            return Ok(character);
        }

        [HttpPost("assignCharacter")]
        public async Task<ActionResult<Character>> AssignCharactertoMovie(CharacterMovies characterMovies)
        {
            bool result = _characterService.AssignCharacterMovie(characterMovies);

            if (result == false) return BadRequest();

            return Ok("Movie added to character");
        }




        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterCreationDTO characterDTO)
        {

            Character character = _characterService.UpdateCharacter(id, characterDTO);
            if (character == null) return NotFound();
            return Ok(character);
        }


        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {

            bool result = _characterService.DeleteCharacter(id);

            if (result == false) return BadRequest("Not found");

            return Ok("Deleted Successfully");
        }


    }
}
