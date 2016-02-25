using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;
using OdeToFood.Mappings;
using OdeToFood.ViewModel;

namespace OdeToFood.Controllers
{
    public class RestaurantController : Controller
    {
        private OdeToFoodDb _db = new OdeToFoodDb();

        //
        // GET: /Restaurant/

        public ActionResult Index()
        {
            List<RestaurantListViewModel> viewModel;
            using (var db = _db)
            {

                var data = db.Restaurants.ToList();

                viewModel = AutoMapper.Mapper.Map<List<Restaurant>, List<RestaurantListViewModel>>(data);

            }

            return View("Index", viewModel);
        }

        //
        // GET: /Restaurant/Details/5

        public ActionResult Details(int id = 0)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                //return View("Not Found");
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Restaurant/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantListViewModel restaurant)
        {
            Restaurant newRestaurant;
            if (ModelState.IsValid)
            {
                newRestaurant = AutoMapper.Mapper.Map<RestaurantListViewModel, Restaurant>(restaurant);
                _db.Restaurants.Add(newRestaurant);
                _db.SaveChanges();
                return RedirectToAction("Index", "Restaurant");
            }
            HttpContext.Response.StatusCode = 500;
            return PartialView("_CreateRestaurant", restaurant);
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}