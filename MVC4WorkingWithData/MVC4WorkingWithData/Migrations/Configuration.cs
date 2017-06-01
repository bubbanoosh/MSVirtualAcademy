namespace MVC4WorkingWithData.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //Allow data loss during a migration
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Models.OdeToFoodDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Models.Restaurant { Name = "Feral Eggroll's Diner", City = "Officer", Country = "Australia",
                    Reviews = new List<Models.RestaurantReview> {
                        new Models.RestaurantReview { Rating = 8, Body = "Not too shabby."}
                    }
                },
                new Models.Restaurant { Name = "Angie's Diner", City = "Holsworthy", Country = "Australia",
                    Reviews = new List<Models.RestaurantReview> {
                        new Models.RestaurantReview { Rating = 10, Body = "Yummmm!" },
                        new Models.RestaurantReview { Rating = 9, Body = "Pretty tasty food!" },
                        new Models.RestaurantReview { Rating = 2, Body = "The food was burnt :(" }
                    }
                },
                new Models.Restaurant { Name = "Fred's Diner", City = "Sydney", Country = "Australia" },
                new Models.Restaurant { Name = "Some Other Hamburgery", City = "Hampton Park", Country = "Australia" },
                new Models.Restaurant { Name = "Jakotay's Hamburgery", City = "Hampton Park", Country = "Australia" },
                new Models.Restaurant { Name = "Thai Laksa", City = "Melbourne", Country = "Australia" },
                new Models.Restaurant { Name = "Sensational Servery", City = "Frankston", Country = "Australia" },
                new Models.Restaurant
                {
                    Name = "Angie Cooks great Pork",
                    City = "Sydney",
                    Country = "Australia",
                    Reviews = new List<Models.RestaurantReview> {
                        new Models.RestaurantReview { Rating = 10, Body = "What an amazing place!"}
                    }
                }
                );

        }
    }
}
