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
    public class PointOfProspectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PointOfProspections
        public ActionResult Index()
        {
            return View(db.PointOfProspections.ToList());
        }

        // GET: PointOfProspections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointOfProspection pointOfProspection = db.PointOfProspections.Find(id);
            if (pointOfProspection == null)
            {
                return HttpNotFound();
            }
            return View(pointOfProspection);
        }

        // GET: PointOfProspections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PointOfProspections/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPointOfProspection,Type")] PointOfProspection pointOfProspection)
        {
            if (ModelState.IsValid)
            {
                db.PointOfProspections.Add(pointOfProspection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pointOfProspection);
        }

        // GET: PointOfProspections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointOfProspection pointOfProspection = db.PointOfProspections.Find(id);
            if (pointOfProspection == null)
            {
                return HttpNotFound();
            }
            return View(pointOfProspection);
        }

        // POST: PointOfProspections/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPointOfProspection,Type")] PointOfProspection pointOfProspection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pointOfProspection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pointOfProspection);
        }

        // GET: PointOfProspections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointOfProspection pointOfProspection = db.PointOfProspections.Find(id);
            if (pointOfProspection == null)
            {
                return HttpNotFound();
            }
            return View(pointOfProspection);
        }

        // POST: PointOfProspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PointOfProspection pointOfProspection = db.PointOfProspections.Find(id);
            db.PointOfProspections.Remove(pointOfProspection);
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
