using PeliculasAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PeliculasAPI.DTOs
{
    public class MovieCreationDTO
    {
        [Display(Name = "Image")]
        [Required]
       
        public string Image { get; set; }

        [Display(Name = "Title")]
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only text")]
        public string Title { get; set; }

        [Display(Name = "Date")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Calification")]
        [Required]
        [Range(1, 5)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only Numbers")]
        public int Calification { get; set; }

        [Display(Name = "genreId")]
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only Numbers")]
        public int genreId { get; set; }

    }
}
