using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        //[ChildActionOnly]
        //public ActionResult BestReview()
        //{
        //    var bestReview = from r in _reviews
        //                     orderby r.Rating descending
        //                     select r;

        //    return PartialView("_Review", bestReview.First());
        //}

        //
        // GET: /Reviews/

        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index([Bind(Prefix="id")] int restaurantId) //este bind é para evitar mudar o routeconfig   
        {
            var restaurant = _db.Restaurants.Find(restaurantId);
            if(restaurant != null)
            {
                return View(restaurant);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid) { 
                using (var db = _db)
                {
                    db.Reviews.Add(review);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = review.RestaurantId });
                }
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            RestaurantReview review;
            using (var db = _db)
            {
                review = db.Reviews.Find(id);
            }
            return View(review);
        }

        [HttpPost]
        //public ActionResult Edit([Bind(Exclude="ReviewerName")] RestaurantReview review) este bind serve para proteger propriedades
            //de serem escritas. Outra forma é usando um view model com as propriedades que apenas queremos editar -> Melhor
        public ActionResult Edit(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                using (var db = _db)
                {
                    db.Entry(review).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = review.RestaurantId });
                }
            }
            return View(review);
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


    }
}
