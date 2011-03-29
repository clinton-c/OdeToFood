using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;
using OdeToFood.Queries;
using System.Threading;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult JsonSearch(string q)
        {
            var restaurants = _db.Restaurants
                                 .Where(r => r.Name.Contains(q) ||
                                             String.IsNullOrEmpty(q))
                                 .Take(10)
                                 .Select(r => new
                                 {
                                     r.Name, r.Address.City, r.Address.Country
                                 });
            return Json(restaurants, JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuickSearch(string term)
        {
            var restaurants = _db.Restaurants
                                 .Where(r => r.Name.Contains(term))
                                 .Take(10)
                                 .Select(r => new { label = r.Name });
            return Json(restaurants, JsonRequestBehavior.AllowGet);
            
        }

        public PartialViewResult Search(string q)
        {
            var restaurants = _db.Restaurants
                                 .Where(r => r.Name.Contains(q) || 
                                             String.IsNullOrEmpty(q))
                                 .Take(10);
            return PartialView("_RestaurantSearchResults", restaurants);
        }


        public PartialViewResult LatestReview()
        {
            var review = _db.Reviews.FindTheLatest(1).Single();
            return PartialView("_Review", review);
        }

        public ViewResult Index()
        {
            ViewBag.Message = "Welcome to Ode To Food";            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Location = "Maryland, USA";

            return View();
        }

        OdeToFoodDB _db = new OdeToFoodDB();
    }
}
