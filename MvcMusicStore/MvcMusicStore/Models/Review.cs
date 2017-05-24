using System.ComponentModel.DataAnnotations;

namespace MvcMusicStore.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Display(Name ="Album")]
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

        public string Contents { get; set; }

        [Required(ErrorMessage ="Enter a freakin email addy!")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string ReviewerEmail { get; set; }
    }
}