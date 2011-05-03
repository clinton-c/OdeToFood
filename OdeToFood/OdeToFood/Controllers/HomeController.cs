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
        [OutputCache(CacheProfile="long", VaryByParam = "q", VaryByHeader="Accept-Language")]
        public ViewResult Index(string q)
        {
            var restaurants = Enumerable.Empty<Restaurant>();
            if (!String.IsNullOrEmpty(q))
            {
                restaurants = _db.Restaurants
                                 .Where(r => r.Name.Contains(q))
                                 .Take(10);
            }
            ViewBag.Message = OdeToFood.Views.Home.HomeResources.Greeting;
            return View(restaurants);
        }

        [OutputCache(CacheProfile="short", VaryByParam="none")]
        public PartialViewResult ChildAction()
        {
            return PartialView();
        }

        public ActionResult About()
        {
            return View();
        }

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
       
        OdeToFoodDB _db = new OdeToFoodDB();
    }
}
