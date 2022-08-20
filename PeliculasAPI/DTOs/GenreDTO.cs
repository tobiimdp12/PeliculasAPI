using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs
{
    public class GenreDTO
    {
        [Display(Name = "Name")]
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only text")]
        public string Name { get; set; }
    }
}
