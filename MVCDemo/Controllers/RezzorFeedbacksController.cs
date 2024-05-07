using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Data;

namespace MVCDemo.Controllers
{
    public class RezzorFeedbacksController : Controller
    {
        private MVCDemoEntities db = new MVCDemoEntities();

        // GET: RezzorFeedbacks
        public ActionResult Index()
        {
            return View(db.tblFeedbacks.ToList());
        }

        // GET: RezzorFeedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFeedback tblFeedback = db.tblFeedbacks.Find(id);
            if (tblFeedback == null)
            {
                return HttpNotFound();
            }
            return View(tblFeedback);
        }

        // GET: RezzorFeedbacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RezzorFeedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Number,IDANumber,Address,Email,Grade")] tblFeedback tblFeedback)
        {
            if (ModelState.IsValid)
            {
                db.tblFeedbacks.Add(tblFeedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblFeedback);
        }

        // GET: RezzorFeedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFeedback tblFeedback = db.tblFeedbacks.Find(id);
            if (tblFeedback == null)
            {
                return HttpNotFound();
            }
            return View(tblFeedback);
        }

        // POST: RezzorFeedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Number,IDANumber,Address,Email,Grade")] tblFeedback tblFeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblFeedback);
        }

        // GET: RezzorFeedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFeedback tblFeedback = db.tblFeedbacks.Find(id);
            if (tblFeedback == null)
            {
                return HttpNotFound();
            }
            return View(tblFeedback);
        }

        // POST: RezzorFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFeedback tblFeedback = db.tblFeedbacks.Find(id);
            db.tblFeedbacks.Remove(tblFeedback);
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
