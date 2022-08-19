using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PeliculasAPI.Models
{
    public class Movies
    {
        public int Id { get; set; }
        
        public string Image { get; set; }
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        [Range(1,5)]
        public int Calification { get; set; }

        [JsonIgnore]
        public List<Character> Characters { get; set; }

        public int genreId { get; set; }

        public Genre Genre { get; set; }
    }
}
