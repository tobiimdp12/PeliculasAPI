using PeliculasAPI.Models;

namespace PeliculasAPI.Repositories
{
    public interface ICharacterRepository
    {
        public IEnumerable<Character> GetAllCharacters();


        //id
        public Character getCharacterById(int id);
 
        //params

        //name
        public IEnumerable<Character> getByName(string name);
 
        public IEnumerable<Character> getByAge(int age);
   

        public IEnumerable<Character> getByMovies(int movieId);



        public Character AddCharacter(Character character);
 

        public bool AssignCharacterMovies(CharacterMovies characterMovies);
   
        public Character UpdateCharacter(Character characterUpdated);

        public bool DeleteCharacter(int id);


    }
}
