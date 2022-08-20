using System.Text.Json.Serialization;

namespace PeliculasAPI.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<Movies> Movies { get; set; }
    }
}
