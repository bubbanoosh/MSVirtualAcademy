using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStoreWithAuthentication.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Album name is required")]
        [Display(Name="Album title")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Choose a band for the album")]
        [Display(Name = "Band")]
        public int BandId { get; set; }

        [UIHint("Choose a Band for this Album")]
        [Display(Name ="Band")]
        public virtual Band Band { get; set; }

        [Display(Name = "Album Reviews")]
        public virtual List<Review> Reviews { get; set; }
    }
}