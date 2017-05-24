using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;
using System;

namespace MvcMusicStore.Models
{
    public class Album
    {

        public int AlbumId { get; set; }

        public int ArtistID { get; set; }


        public string Title { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual List<Review> Reviews { get; set; }

        [ScaffoldColumn(false)]
        [BindNever]
        [Required]
        public DateTime Created { get; set; }

    }
}