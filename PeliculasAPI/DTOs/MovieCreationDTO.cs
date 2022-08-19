using PeliculasAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PeliculasAPI.DTOs
{
    public class MovieCreationDTO
    {
        public string Image { get; set; }
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        [Range(1, 5)]
        public int Calification { get; set; }

        public int genreId { get; set; }

    }
}
