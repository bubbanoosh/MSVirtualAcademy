using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC4WorkingWithData_2.Models;
using MVCWorkingWithData_2.Models;

namespace MVCWorkingWithData_2.Controllers
{
    public class RestaurantReviewsController : Controller
    {
        private MVCWorkingWithData_2Context db = new MVCWorkingWithData_2Context();

        // GET: RestaurantReviews
        public ActionResult Index([Bind(Prefix = "Id")] int? restaurantId)
        {
            ////EF created this below (A list of all reviews and restaurants)
            //var restaurantReviews = db.RestaurantReviews.Include(r => r.Restaurant);
            //return View(restaurantReviews.ToList());


            if (restaurantId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(restaurantId);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);



        }

        // GET: RestaurantReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReview restaurantReview = db.RestaurantReviews.Find(id);
            if (restaurantReview == null)
            {
                return HttpNotFound();
            }
            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Create
        [HttpGet]
        public ActionResult Create(int restaurantId = 0)
        {
            //ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name");
            return View();
        }

        // POST: RestaurantReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rating,Body,RestaurantId")] RestaurantReview restaurantReview)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantReviews.Add(restaurantReview);
                db.SaveChanges();
                return RedirectToAction("Index", new { Id = restaurantReview.RestaurantId } );
            }

            //  ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", restaurantReview.RestaurantId);
            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RestaurantReview restaurantReview = db.RestaurantReviews.Find(id);
            if (restaurantReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", restaurantReview.RestaurantId);

            return View(restaurantReview);
        }

        // POST: RestaurantReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rating,Body,RestaurantId")] RestaurantReview restaurantReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { Id = restaurantReview.RestaurantId });
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", restaurantReview.RestaurantId);
            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReview restaurantReview = db.RestaurantReviews.Find(id);
            if (restaurantReview == null)
            {
                return HttpNotFound();
            }
            return View(restaurantReview);
        }

        // POST: RestaurantReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantReview restaurantReview = db.RestaurantReviews.Find(id);
            db.RestaurantReviews.Remove(restaurantReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
