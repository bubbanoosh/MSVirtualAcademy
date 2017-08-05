using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public abstract class BookForManipulationDto
    {
        [Required(ErrorMessage = "Fill out a freaking Title will ya!")]
        [MaxLength(100, ErrorMessage = "Title is too long...")]
        public string Title { get; set; }

        // VIRTUAL - Great when you have an implementation in the base class
        //           But you want to allow OVERRIDE
        [MaxLength(500, ErrorMessage = "Description should be less than 500 length.")]
        public virtual string Description { get; set; }
    }
}
