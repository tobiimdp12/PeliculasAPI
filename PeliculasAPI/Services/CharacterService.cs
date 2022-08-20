using AutoMapper;
using PeliculasAPI.DTOs;
using PeliculasAPI.Models;
using PeliculasAPI.Repositories;

namespace PeliculasAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }


        public IEnumerable<Character> GetAllCharacters()
        {
            return _characterRepository.GetAllCharacters();
        }


        public IEnumerable<CharacterDTO> GetCharactersImageName()
        {
            var characters = _characterRepository.GetAllCharacters();

            var charactersToReturn = _mapper.Map<IEnumerable<CharacterDTO>>(characters);

            return charactersToReturn;
        }

        public Character GetById(int Id)
        {
            var character = _characterRepository.getCharacterById(Id);


            return character;
        }

        public IEnumerable<Character> getByName(string name)
        {
            var characters = _characterRepository.getByName(name);

            return characters;
        }

        public IEnumerable<Character> getByAge(int age)
        {
            var characters = _characterRepository.getByAge(age);
            return characters;
        }


        public IEnumerable<Character> getByMovies(int movieId)
        {

            var characters = _characterRepository.getByMovies(movieId);

            return characters;
        }
        public Character AddCharacter(CharacterCreationDTO characterDTO)
        {
         
            Character character = _mapper.Map<Character>(characterDTO);

            var characters = getByName(character.Name);
           
            if (characters.Any())
            {
                return null;
            }

     
            _characterRepository.AddCharacter(character);
            return character;
        }

        public bool AssignCharacterMovie(CharacterMovies characterMovies)
        {

            bool result = _characterRepository.AssignCharacterMovies(characterMovies);

            return result;
        }

        public Character UpdateCharacter(int id, CharacterCreationDTO characterUpdated)
        {
            if (_characterRepository.getCharacterById(id) == null)
            {
                return null;
            }

            Character character = _characterRepository.getCharacterById(id);

            character = _mapper.Map(characterUpdated, character);//para que el id no se transforme en 0

            character = _characterRepository.UpdateCharacter(character);
            return character;
        }
        public bool DeleteCharacter(int id)
        {

            return _characterRepository.DeleteCharacter(id);
        }

    }
}
