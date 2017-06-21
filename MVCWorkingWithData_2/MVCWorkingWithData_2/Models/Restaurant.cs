using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVCWorkingWithData_2.CustomValidation; //My Validation Attributes Class

namespace MVC4WorkingWithData_2.Models
{

    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is manditory")]
        [Display(Name = "Restaurant Name")]
        [DisplayFormat(NullDisplayText = "Bob's Diner")]
        [StringLength(50)]
        [MaxWords(2, ErrorMessage ="Why so many words?")] //Custom Validation Attribute
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter a City")]
        [Display(Name = "City/Suburb")]
        [DisplayFormat(NullDisplayText ="City here")]
        [StringLength(50)]
        public string City { get; set; }

        public string Country { get; set; }

        //NOTE:
        //  virtual will create a wrapper class
        //  and will do a second database call to retrieve the reviews
        //  when it is called. Inefficient
        //  !! This is why it's better to use the following in the Controller
        //  ------------------------------------------------
        //      var restaurantReviews = db.RestaurantReviews.Include(r => r.Restaurant);
        //      return View(restaurantReviews.ToList());
        //  ------------------------------------------------

        public virtual ICollection<RestaurantReview> Reviews { get; set; }
    }
}