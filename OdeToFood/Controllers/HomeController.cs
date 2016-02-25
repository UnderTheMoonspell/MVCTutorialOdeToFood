using OdeToFood.Models;
using OdeToFood.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PagedList;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Restaurants
                    .Where(r => r.Name.StartsWith(term))
                    .Take(10)
                    .Select(r => new
                    {
                        label = r.Name
                    });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            List<RestaurantListViewModel> viewModel;
            using (var db = _db)
            {

                var data = _db.Restaurants
                    .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                    .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                    .ToList();

                viewModel = AutoMapper.Mapper.Map<List<Restaurant>, List<RestaurantListViewModel>>(data);

            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", viewModel.ToPagedList(page, 2));
            }

            return View(viewModel.ToPagedList(page, 2));
            //var model = _db.Restaurants
            //    .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
            //    .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
            //    .Take(10)
            //    .Select(r => new RestaurantListViewModel
            //    {
            //        Id = r.Id,
            //        Name = r.Name,
            //        City = r.City,
            //        Country = r.Country,
            //        ReviewsCount = r.Reviews.Count()
            //    });
        }

        [Authorize]
        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Bernardo";
            model.Location = "Portugal";
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
