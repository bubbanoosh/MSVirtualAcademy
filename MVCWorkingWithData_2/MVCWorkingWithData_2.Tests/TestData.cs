using MVC4WorkingWithData_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWorkingWithData_2.Tests
{
    class TestData
    {
        //FAKE IN MEMORY RESTAURANT DATA FOR TESTING
        public static IQueryable<Restaurant> Restaurants
        {
            get
            {
                var restaurants = new List<Restaurant>();

                for (int i = 0; i < 1000; i++)
                {
                    var restaurant = new Restaurant();
                    restaurant.Reviews = new List<RestaurantReview>()
                    {
                        new RestaurantReview() { Rating = 4 }
                    };

                    restaurants.Add(restaurant);
                }
                return restaurants.AsQueryable();
            }
        }
    }
}
