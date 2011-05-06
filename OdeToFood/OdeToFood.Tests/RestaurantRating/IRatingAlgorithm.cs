using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Models;

namespace OdeToFood.Tests.ReviewTests
{
    interface IRatingAlgorithm
    {
        RateResult Compute(IList<Review> reviews);
    }
}
