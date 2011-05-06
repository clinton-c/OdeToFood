using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OdeToFood.Models;

// 
// A restaurant's overall rating can be caluclated using various methods.
// For this application we'll want to try different methods over time, 
// but for starters we'll allow an administrator to toggle between two 
// different techniques.
//
// 1. Simple mean of the "rating" value for the most recent n reviews
//    (the admin can configure the value n).
//
// 2. Weighted mean of the last n reviews. The most recent n/2 reviews
//    will be weighted twice as much and the oldest n/2 reviews. 
//
// Overall rating should be a whole number.


namespace OdeToFood.Tests.ReviewTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Simple_Averaging_For_One_Review()
        {
            int[] ratings = new int[] { 4 };
            var data = BuildRestaurantForReview(ratings);

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRate(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(4, result.Rating);
        }

        [Test]
        public void Simple_Averaging_For_Two_Reviews()
        {
            var data = BuildRestaurantForReview(4, 8);

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRate(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(6, result.Rating);
        }

        [Test]
        public void Weighted_Averaging_For_Two_Reviews()
        {
            var data = BuildRestaurantForReview(3, 9);

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRate(new WeightedRatingAlgorithm(), 10);

            Assert.AreEqual(5, result.Rating);
        }

        [Test]
        public void Rating_Includes_Only_First_N_Reviews()
        {
            var data = BuildRestaurantForReview(1, 1, 1, 10, 10, 10);

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRate(new SimpleRatingAlgorithm(), 3);

            Assert.AreEqual(1, result.Rating);
        }

        private Restaurant BuildRestaurantForReview(params int[] ratings)
        {
            var result = new Restaurant();
            result.Reviews =
                ratings.Select(r => new Review { Rating = r })
                       .ToList();
            return result;
        }
    }
}
