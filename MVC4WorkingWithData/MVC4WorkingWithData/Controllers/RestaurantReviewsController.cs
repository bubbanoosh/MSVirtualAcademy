using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC4WorkingWithData.Models;

namespace MVC4WorkingWithData.Controllers
{
    public class RestaurantReviewsController : Controller
    {
        private MVC4WorkingWithDataContext db = new MVC4WorkingWithDataContext();

        // GET: RestaurantReviews
        public ActionResult Index([Bind(Prefix="Id")] int? restaurantId)
        {
            //if (restaurantId == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Restaurant restaurant = db.Restaurants.Find(restaurantId);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: RestaurantReviews/Create
        public ActionResult Create()
        {
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
                db.Reviews.Add(restaurantReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReview restaurantReview = db.Reviews.Find(id);
            if (restaurantReview == null)
            {
                return HttpNotFound();
            }
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
                return RedirectToAction("Index");
            }
            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReview restaurantReview = db.Reviews.Find(id);
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
            RestaurantReview restaurantReview = db.Reviews.Find(id);
            db.Reviews.Remove(restaurantReview);
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
