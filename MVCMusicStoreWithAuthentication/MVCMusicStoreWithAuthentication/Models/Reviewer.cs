using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStoreWithAuthentication.Models
{
    public class Reviewer
    {
        [Key]
        public int ReviewerId { get; set; }

        [Required(ErrorMessage = "Reviewer name is required")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

    }
}