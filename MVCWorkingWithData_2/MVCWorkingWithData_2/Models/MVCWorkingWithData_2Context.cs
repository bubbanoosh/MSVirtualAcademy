using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWorkingWithData_2.Models
{


    public interface IMVCWorkingWithData_2 : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
    }


    public class MVCWorkingWithData_2Context : DbContext, IMVCWorkingWithData_2 
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MVCWorkingWithData_2Context() : base("name=MVCWorkingWithData_2Context")
        {
        }

        public DbSet<MVC4WorkingWithData_2.Models.Restaurant> Restaurants { get; set; }
        public DbSet<MVC4WorkingWithData_2.Models.RestaurantReview> RestaurantReviews { get; set; }

        IQueryable<T> IMVCWorkingWithData_2.Query<T>()
        {
            return Set<T>();
        }

    }
}
