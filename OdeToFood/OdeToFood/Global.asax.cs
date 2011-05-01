using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OdeToFood.Infrastructure;
using OdeToFood.Models;
using System.Data.Entity;

namespace OdeToFood
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                    "Cuisine",
                    "cuisine/{name}",
                    new { controller = "Cuisine", action = "Search", name=UrlParameter.Optional }
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {

            //Database.SetInitializer(new OdeToFoodDBInitializer());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }

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