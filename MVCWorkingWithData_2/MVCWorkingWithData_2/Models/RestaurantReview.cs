using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC4WorkingWithData_2.Models
{
    public class RestaurantReview
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 10)]
        [Required(ErrorMessage ="Ratings from 1 to 10 only.")]
        [Display(Name = "Review Rating")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Write your review?")]
        [Display(Name = "Reviewer Comment")]
        [DisplayFormat(NullDisplayText = "Excellent, wooo hooo!")]
        [StringLength(1024)]
        public string Body { get; set; }

        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
    }
}