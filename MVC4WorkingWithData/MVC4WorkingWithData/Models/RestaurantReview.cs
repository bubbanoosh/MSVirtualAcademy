using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC4WorkingWithData.Models
{
    public class RestaurantReview
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }

        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
    }
}