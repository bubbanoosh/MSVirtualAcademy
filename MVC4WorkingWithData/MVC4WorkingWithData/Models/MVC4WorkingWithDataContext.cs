using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC4WorkingWithData.Models
{
    public class MVC4WorkingWithDataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MVC4WorkingWithDataContext() : base("name=MVC4WorkingWithData")
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }

        public System.Data.Entity.DbSet<MVC4WorkingWithData.Models.RestaurantListViewModel> RestaurantListViewModels { get; set; }
    }
}
