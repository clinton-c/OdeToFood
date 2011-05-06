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
        public ActionResult Index(string q = null)
        {
            var restaurants = _db.Restaurants
                                 .Where(r => r.Name.Contains(q) || q == null)
                                 .Take(10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_RestaurantList", restaurants);
            }
            return View(restaurants);
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
      
        OdeToFoodDB _db = new OdeToFoodDB();
    }
}
