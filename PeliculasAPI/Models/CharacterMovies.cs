using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Models
{
    public class CharacterMovies
    {
        [Display(Name ="CharacterId")]
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only Numbers")]
        public int CharacterId { get; set; }

        [Display(Name = "MovieId")]
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only Numbers")]
        public int MovieId { get; set; }
    }
}
