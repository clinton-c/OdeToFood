﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;
using OdeToFood.Queries;
using System.Data;
using Microsoft.Security.Application;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDB _db = new OdeToFoodDB();

        //
        // GET: /Reviews/

        public ActionResult Index()
        {
            var model = _db.Reviews.FindTheLatest(3);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult BestReview()
        {
            var model = _db.Reviews.FindTheBest();
            return PartialView("_Review", model);
        }

        //
        // GET: /Reviews/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Reviews/Create

        public ActionResult Create()
        {
            return View(new Review());
        } 

        //
        // POST: /Reviews/Create

        [HttpPost]
        public ActionResult Create(int restaurantID, Review newReview)
        {
            try
            {
                var restaurant = _db.Restaurants.Single(r => r.ID == restaurantID);
                restaurant.Reviews.Add(newReview);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }        
        //
        // GET: /Reviews/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var review = _db.Reviews.FindById(id);
            return View(review);
        }

        //
        // POST: /Reviews/Edit/5

        [HttpPost]
        [Authorize]  
        [ValidateAntiForgeryToken]  
        public ActionResult Edit(Review review)
        {            
            if (ModelState.IsValid)
            {
                review.Body = Sanitizer.GetSafeHtmlFragment(review.Body);
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(review);
        }       

        //
        // GET: /Reviews/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Reviews/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
