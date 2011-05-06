using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Models;

namespace OdeToFood.Tests.ReviewTests
{
    class RestaurantRater
    {
        public RestaurantRater(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }

        public RateResult ComputeRate(IRatingAlgorithm algorithm, 
                                     int numberOfReviewsToUse)
        {
            return algorithm.Compute(_restaurant.Reviews
                                    .Take(numberOfReviewsToUse).ToList());
        }

        Restaurant _restaurant;
    }
}
