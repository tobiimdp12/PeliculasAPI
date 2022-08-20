using PeliculasAPI.DTOs;
using PeliculasAPI.Models;

namespace PeliculasAPI.Services
{
    public interface ICharacterService
    {




        public IEnumerable<Character> GetAllCharacters();




        public IEnumerable<CharacterDTO> GetCharactersImageName();


        public Character GetById(int Id);

        public IEnumerable<Character> getByName(string name);


        public IEnumerable<Character> getByAge(int age);



        public IEnumerable<Character> getByMovies(int movieId);

        public Character AddCharacter(CharacterCreationDTO characterDTO);



        public bool AssignCharacterMovie(CharacterMovies characterMovies);


        public Character UpdateCharacter(int id, CharacterCreationDTO characterUpdated);

        public bool DeleteCharacter(int id);

    }
}
