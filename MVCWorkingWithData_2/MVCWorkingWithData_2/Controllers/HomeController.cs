using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWorkingWithData_2.ViewModels;
using MVCWorkingWithData_2.Models;
using PagedList;
using MVC4WorkingWithData_2.Models;

namespace MVCWorkingWithData_2.Controllers
{
    public class HomeController : Controller
    {

        private IMVCWorkingWithData_2 _db;



        public HomeController()
        {
            _db = new MVCWorkingWithData_2Context();
        }
        public HomeController(IMVCWorkingWithData_2 db)
        {
            //This one will be  called from UNIT tests
            // and passed "in memory data" instead.
            _db = db;
        }



        /// <summary>
        /// Returns Json from JQuery for the Autocomplete
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        //JQuery docs says JQuery will send a 'term' in the ajax request
        public ActionResult AutoComplete(string term)
        {

            var model =
                _db.Query<Restaurant>()
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                //JQuery Documentation states:
                //      you must have 
                //      a lable 
                //      or a value 
                //      or a label and a value 
                //  to store the results
                .Select(r => new {
                    label = r.Name
                });


            //return Json 
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 120)]
        public ActionResult SayHello()
        {
            return Content("Hello from the ChildActionOnly Action");
        }

        [OutputCache(Duration = 20)]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            // *** VIEWMODEL ***
            // *** VIEWMODEL ***
            //Extension method syntax (Most popular restaurants by reviews by Average)
            var model =
                _db.Query<Restaurant>()
                    .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                    //Where clause
                    .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                    .Select(r => new RestaurantListViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        Country = r.Country,
                        CountOfReviews = r.Reviews.Count()
                    }
                    ).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

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