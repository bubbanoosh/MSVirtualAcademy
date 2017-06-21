using MVC4WorkingWithData_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWorkingWithData_2.Tests.Features
{
    public interface IRatingAlgorithm
    {
        RatingResult Compute(IList<RestaurantReview> reviews);
    }

    /// <summary>
    /// Simple Algorithm
    /// </summary>
    public class SimpleRatingAlgorith : IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var result = new RatingResult();
            result.Rating = (int)reviews.Average(r => r.Rating);
            return result;
        }
    }

    /// <summary>
    /// Weighted Algorithm
    /// </summary>
    public class WeightedRatingAlgorith : IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var result = new RatingResult();
            var counter = 0;
            var total = 0;

            for (int i = 0; i < reviews.Count(); i++)
            {
                if (i < reviews.Count() / 2)
                {
                    counter += 2;
                    total += reviews[i].Rating * 2;
                }
                else
                {
                    counter += 1;
                    total += reviews[i].Rating;
                }
            }

            result.Rating = total / counter;
            return result;
        }
    }
}
