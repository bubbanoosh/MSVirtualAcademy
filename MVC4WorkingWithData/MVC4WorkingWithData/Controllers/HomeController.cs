using MVC4WorkingWithData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4WorkingWithData.Controllers
{
    public class HomeController : Controller
    {

        private MVC4WorkingWithDataContext _db = new MVC4WorkingWithDataContext();

        public ActionResult Index(string searchTerm = null)
        {

            // *** VIEWMODEL ***
            // *** VIEWMODEL ***
            //Extension method syntax (Most popular restaurants by reviews by Average)
            var model =
                _db.Restaurants
                    .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                    //Where clause
                    .Where (r => searchTerm == null || r.Name.StartsWith(searchTerm))
                    .Take(10)
                    .Select(r => new RestaurantListViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        Country = r.Country,
                        CountOfReviews = r.Reviews.Count()
                    }
                    );

            // *** VIEWMODEL ***
            // *** VIEWMODEL ***
            //Comprehension syntax (Most popular restaurants by reviews by Average)
            //var model = from r in _db.Restaurants
            //            orderby r.Reviews.Average(review => review.Rating) descending
            //            // supply with Reviews.Count() in a "VIEWMODEL"
            //            select new RestaurantListViewModel
            //            {
            //                Id = r.Id,
            //                Name = r.Name,
            //                City = r.City,
            //                Country = r.Country,
            //                CountOfReviews = r.Reviews.Count()
            //            };


            //var model = _db.Restaurants.ToList();

            ////Comprehension syntax
            //var model = from r in _db.Restaurants
            //            orderby r.Name ascending
            //            select r;

            ////Comprehension syntax (Most popular restaurants by reviews)
            //var model = from r in _db.Restaurants
            //            orderby r.Reviews.Count() descending
            //            select r;

            ////Comprehension syntax (Most popular restaurants by reviews by Average)
            //var model = from r in _db.Restaurants
            //            orderby r.Reviews.Average(review => review.Rating) descending
            //            select r;


            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
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