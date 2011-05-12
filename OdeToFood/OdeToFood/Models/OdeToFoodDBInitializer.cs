using System;
using System.Collections.Generic;
using System.Data.Entity;
using OdeToFood.Models;

namespace OdeToFood
{
    public class OdeToFoodDBInitializer : 
        DropCreateDatabaseAlways<OdeToFoodDB>
    {
        protected override void Seed(OdeToFoodDB context)
        {            
            context.Restaurants.Add(new Restaurant
                                        {
                                            Name = "Marrakesh",
                                            Address = new Address
                                                          {
                                                              City = "Washington",
                                                              State="D.C.",
                                                              Country = "USA"
                                                          }
                                        });

            context.Restaurants.Add(new Restaurant
                                        {
                                            Name = "Sabatino's",
                                            Address = new Address
                                                          {
                                                              City = "Baltimore", 
                                                              State = "MD",
                                                              Country = "USA"
                                                          }
                                        });

            context.Restaurants.Add(new Restaurant
                                        {
                                            Name = "The Kings Contrivance",
                                            Address = new Address
                                                          {
                                                              City = "Columbia",
                                                              State = "MD",
                                                              Country = "USA"
                                                          }
                                        });

            context.Restaurants.Add(new Restaurant
                                        {
                                            Name = "Yellow Brick Bank Restaurant",
                                            Address = new Address
                                                          {
                                                              City="Columbia",
                                                              State="MD",
                                                              Country="USA"
                                                          },
                                            Reviews = new List<Review> {
                                                                           new Review{
                                                                                         Rating= 9,
                                                                                         Body="This is restaurant is <em>great!</em>",
                                                                                         DiningDate = new DateTime(2001,1,1)
                                                                                     },
                                                                           new Review{
                                                                                         Rating= 9,
                                                                                         Body="This is restaurant is <em>great!</em>",
                                                                                         DiningDate = new DateTime(2001,1,1)
                                                                                     }
                                                                       }
                                        });

            base.Seed(context);
        }
    }
}