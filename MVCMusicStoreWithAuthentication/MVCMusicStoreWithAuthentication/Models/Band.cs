using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace MVCMusicStoreWithAuthentication.Models
{
    public class Band
    {
        [Key]
        public int BandId { get; set; }

        public string BandName { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Url(ErrorMessage = "Please enter a valid url")]
        [DisplayName("Website")]
        public string Website { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public virtual List<Artist> Artists { get; set; }
    }
}