using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Data;
using PeliculasAPI.Models;

namespace PeliculasAPI.Repositories
{
    public class CharacterRepository:ICharacterRepository
    {
        private readonly DataContext _context;
       
        public CharacterRepository(DataContext context)
        {
            _context = context;

        }

        public IEnumerable<Character> GetAllCharacters()
        {
            return _context.Characters.Include(m => m.Movies).ThenInclude(g => g.Genre).ToList();
        }
        
        //id
        public Character getCharacterById(int id)
        {
            return _context.Characters.Where(c => c.Id == id).Include(m => m.Movies).ThenInclude(g=>g.Genre).FirstOrDefault(); 
        }
    
        public IEnumerable<Character> getByName(string name)
        {
            var characters = _context.Characters.Where(u => u.Name==name).Include(m => m.Movies).ThenInclude(g => g.Genre);
            return characters;
        }
      
        public IEnumerable<Character> getByAge(int age)
        {
            var characters = _context.Characters.Where(u => u.Age == age).Include(m => m.Movies).ThenInclude(g => g.Genre);
            return characters;
        }
      

        public IEnumerable<Character> getByMovies(int movieId)
        {
            Movies movie = _context.Movies.Find(movieId);

            if(movie== null) return null;
        
            var characters = _context.Characters.Where(c => c.Movies.Contains(movie)).Include(m => m.Movies).ThenInclude(g => g.Genre);

            return characters;
        }


        public Character AddCharacter(Character character)
        {
            _context.Characters.Add(character);
             _context.SaveChanges();

            return character;
        }

        public  bool AssignCharacterMovies(CharacterMovies characterMovies)
        {
            var character =  _context.Characters
                .Where(c => c.Id == characterMovies.CharacterId)
                .Include(c => c.Movies)
                .FirstOrDefault();

            if (character == null)

                return false;

            var movie =  _context.Movies.Find(characterMovies.MovieId);

            if (movie == null)
                return false;

            character.Movies.Add(movie);

            _context.SaveChanges();

            return true;
        }
        public Character UpdateCharacter(Character characterUpdated)
        {
            try
            {
               
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return characterUpdated;
        }
        public bool DeleteCharacter(int id)
        {
            var character =  _context.Characters.Find(id);

            if(character == null) return false;
            Console.WriteLine(character);
            _context.Characters.Remove(character);
            _context.SaveChanges();
            return true;
        }
    }
}
