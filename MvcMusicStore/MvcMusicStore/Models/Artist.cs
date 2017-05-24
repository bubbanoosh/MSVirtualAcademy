using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace MvcMusicStore.Models
{
    public class Artist
    {

        public int ArtistID { get; set; }

        public string Name { get; set; }

        public virtual List<Album> Albums { get; set; }


        [ScaffoldColumn(false)]
        [BindNever]
        [Required]
        public DateTime Created { get; set; }

    }
}