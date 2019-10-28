using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Web.Models;

namespace Web.Controllers
{
    public class ReactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reacts
        public ActionResult Index()
        {
            return View(db.Reacts.ToList());
        }

        // GET: Reacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            React react = db.Reacts.Find(id);
            if (react == null)
            {
                return HttpNotFound();
            }
            return View(react);
        }

        // GET: Reacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reacts/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReact,Type")] React react)
        {
            if (ModelState.IsValid)
            {
                db.Reacts.Add(react);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(react);
        }

        // GET: Reacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            React react = db.Reacts.Find(id);
            if (react == null)
            {
                return HttpNotFound();
            }
            return View(react);
        }

        // POST: Reacts/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReact,Type")] React react)
        {
            if (ModelState.IsValid)
            {
                db.Entry(react).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(react);
        }

        // GET: Reacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            React react = db.Reacts.Find(id);
            if (react == null)
            {
                return HttpNotFound();
            }
            return View(react);
        }

        // POST: Reacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            React react = db.Reacts.Find(id);
            db.Reacts.Remove(react);
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
