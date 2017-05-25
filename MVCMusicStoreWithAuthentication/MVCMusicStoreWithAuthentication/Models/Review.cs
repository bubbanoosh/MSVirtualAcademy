using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStoreWithAuthentication.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

        [Required]
        public virtual Reviewer Reviewer { get; set; }
    }
}