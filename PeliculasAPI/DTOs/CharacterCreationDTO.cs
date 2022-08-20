using PeliculasAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PeliculasAPI.DTOs
{
    public class CharacterCreationDTO
    {
        [Display(Name = "Image")]
        [Required]
      
        public string Image { get; set; }
        [Display(Name = "Name")]
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only text")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage ="Only Numbers")]
        public int Age { get; set; }

        [Display(Name = "Weight")]
        [Required]

        public decimal Weight { get; set; }

        [Display(Name = "History")]
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only text")]
        public string History { get; set; }


    }
}
