using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC4WorkingWithData_2.Models;
using System.Collections.Generic;
using System.Linq;

/*
NOTES:

A restaurant's overalll rating can be calculated using various methods.
For this application we'll want to try different methods over time,
but for starters we'll allow an administrator to toggle between two
different techniques.

    1. Simple mean of the 'Rating' value for th most recent n reviews
        (the admin can configure n value)

    2. Weighted mean of the last n reviews. The most recent n/2 reviews
        will be weighted twice as much as the oldest n/2 reviews.

    Overall Rating should be a whole number.
 
*/

namespace MVCWorkingWithData_2.Tests.Features
{
    [TestClass]
    public class RatingTests
    {
        [TestMethod]
        public void Computes_Results_For_One_Review()
        {

            var data = Build_Restaurant_And_Reviews(4);

            var rater = new RestaurantRater(data);
            var result = rater.ComputeResult(new SimpleRatingAlgorith(), 10);

            Assert.AreEqual(4, result.Rating);
        }

        [TestMethod]
        public void Computes_Results_For_Two_Reviews()
        {

            //var data = new Restaurant();
            //data.Reviews = new List<RestaurantReview>();
            //data.Reviews.Add(new RestaurantReview() { Rating = 4 });
            //data.Reviews.Add(new RestaurantReview() { Rating = 8 });

            //var data = BuildRestaurantAndReviews(ratings: new[] { 4, 8 });
            var data = Build_Restaurant_And_Reviews(4, 8);

            var rater = new RestaurantRater(data);
            var result = rater.ComputeResult(new SimpleRatingAlgorith(), 10);

            Assert.AreEqual(6, result.Rating);
        }

        [TestMethod]
        public void Rating_Only_Inclues_First_N_Reviews()
        {
            var data = Build_Restaurant_And_Reviews(1,1,1,10,10,10);

            var rater = new RestaurantRater(data);
            var result = rater.ComputeResult(new SimpleRatingAlgorith(), 3);

            Assert.AreEqual(1, result.Rating);
        }

        [TestMethod]
        public void Weighted_Average_For_Two_Reviews()
        {
            var data = Build_Restaurant_And_Reviews(3,9);

            var rater = new RestaurantRater(data);
            var result = rater.ComputeResult(new WeightedRatingAlgorith(), 10);

            Assert.AreEqual(5, result.Rating);
        }

        private Restaurant Build_Restaurant_And_Reviews(params int[] ratings)
        {
            var restaurant = new Restaurant();

            //need using statement for System.Linq
            restaurant.Reviews =
                ratings.Select(r => new RestaurantReview { Rating = r })
                .ToList();

            return restaurant;
        }
    }
}
