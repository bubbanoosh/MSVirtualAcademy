using Microsoft.AspNet.Identity;

namespace MVCWorkingWithData_2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCWorkingWithData_2.Models.MVCWorkingWithData_2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //Allow data loss during a migration
            AutomaticMigrationDataLossAllowed = true;

            ContextKey = "MVCWorkingWithData_2.Models.MVCWorkingWithData_2Context";
        }

        protected override void Seed(MVCWorkingWithData_2.Models.MVCWorkingWithData_2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Restaurants.AddOrUpdate(r => r.Name,
                new MVC4WorkingWithData_2.Models.Restaurant
                {
                    Name = "Feral Eggroll's Diner",
                    City = "Officer",
                    Country = "Australia",
                    Reviews = new List<MVC4WorkingWithData_2.Models.RestaurantReview> {
                        new MVC4WorkingWithData_2.Models.RestaurantReview { Rating = 8, Body = "Not too shabby."}
                    }
                },
                new MVC4WorkingWithData_2.Models.Restaurant
                {
                    Name = "Angie's Diner",
                    City = "Holsworthy",
                    Country = "Australia",
                    Reviews = new List<MVC4WorkingWithData_2.Models.RestaurantReview> {
                        new MVC4WorkingWithData_2.Models.RestaurantReview { Rating = 10, Body = "Yummmm!" },
                        new MVC4WorkingWithData_2.Models.RestaurantReview { Rating = 9, Body = "Pretty tasty food!" },
                        new MVC4WorkingWithData_2.Models.RestaurantReview { Rating = 2, Body = "The food was burnt :(" }
                    }
                },
                new MVC4WorkingWithData_2.Models.Restaurant { Name = "Fred's Diner", City = "Sydney", Country = "Australia" },
                new MVC4WorkingWithData_2.Models.Restaurant { Name = "Some Other Hamburgery", City = "Hampton Park", Country = "Australia" },
                new MVC4WorkingWithData_2.Models.Restaurant { Name = "Jakotay's Hamburgery", City = "Hampton Park", Country = "Australia" },
                new MVC4WorkingWithData_2.Models.Restaurant { Name = "Thai Laksa", City = "Melbourne", Country = "Australia" },
                new MVC4WorkingWithData_2.Models.Restaurant { Name = "Sensational Servery", City = "Frankston", Country = "Australia" },
                new MVC4WorkingWithData_2.Models.Restaurant
                {
                    Name = "Angie Cooks great Pork",
                    City = "Sydney",
                    Country = "Australia",
                    Reviews = new List<MVC4WorkingWithData_2.Models.RestaurantReview> {
                        new MVC4WorkingWithData_2.Models.RestaurantReview { Rating = 10, Body = "What an amazing place!"}
                    }
                }
                );

            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name, 
                    new MVC4WorkingWithData_2.Models.Restaurant { Name = "Diner " + i.ToString(), City = "Sydney", Country = "Australia" });
            }
        }

    }
}
