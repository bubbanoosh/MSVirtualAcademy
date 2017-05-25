using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC4WorkingWithData.Models
{
    public class OdeToFoodDb : DbContext
    {

        public OdeToFoodDb() : base("name=MVC4WorkingWithData")
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }

    }
}