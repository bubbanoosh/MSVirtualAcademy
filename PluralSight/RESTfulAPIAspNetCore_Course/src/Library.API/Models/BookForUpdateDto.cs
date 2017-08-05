using System.ComponentModel.DataAnnotations;

namespace Library.API.Models
{
    // Derives from the ABSTRACT class
    public class BookForUpdateDto : BookForManipulationDto
    {
        // OVERRIDE the VIRTUAL Prop from the ABSTRACT class
        [Required(ErrorMessage = "You should fill out Description")]
        public override string Description { get; set; }
    }
}
