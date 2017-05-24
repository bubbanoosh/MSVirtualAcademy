using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreWithAuthentication.Models;

namespace MVCMusicStoreWithAuthentication.Controllers
{
    public class ReviewersController : Controller
    {
        private MVCMusicStoreWithAuthenticationContext db = new MVCMusicStoreWithAuthenticationContext();

        // GET: Reviewers
        public async Task<ActionResult> Index()
        {
            return View(await db.Reviewers.ToListAsync());
        }

        // GET: Reviewers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviewer reviewer = await db.Reviewers.FindAsync(id);
            if (reviewer == null)
            {
                return HttpNotFound();
            }
            return View(reviewer);
        }

        // GET: Reviewers/Create
        [Authorize()]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviewers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReviewerId,Name,Email")] Reviewer reviewer)
        {
            if (ModelState.IsValid)
            {
                db.Reviewers.Add(reviewer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(reviewer);
        }

        // GET: Reviewers/Edit/5
        [Authorize()]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviewer reviewer = await db.Reviewers.FindAsync(id);
            if (reviewer == null)
            {
                return HttpNotFound();
            }
            return View(reviewer);
        }

        // POST: Reviewers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReviewerId,Name,Email")] Reviewer reviewer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reviewer);
        }

        // GET: Reviewers/Delete/5
        [Authorize()]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviewer reviewer = await db.Reviewers.FindAsync(id);
            if (reviewer == null)
            {
                return HttpNotFound();
            }
            return View(reviewer);
        }

        // POST: Reviewers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reviewer reviewer = await db.Reviewers.FindAsync(id);
            db.Reviewers.Remove(reviewer);
            await db.SaveChangesAsync();
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
