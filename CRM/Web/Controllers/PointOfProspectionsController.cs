using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Services;
using Web.Models;

namespace Web.Controllers
{
    public class PointOfProspectionsController : Controller
    {
        private PointofprospectionService ps = new PointofprospectionService();

        // GET: PointOfProspections
        public ActionResult Index()
        {
            return View(ps.GetAll().ToList());
        }

        public ActionResult IndexFront()
        {
            return View(ps.GetAll().ToList());
        }

        // GET: PointOfProspections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointOfProspection pointOfProspection = ps.GetById((long)id);
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
        public ActionResult Create([Bind(Include = "IdPointOfProspection,Type,name,lat,lon")] PointOfProspection pointOfProspection)
        {
            if (ModelState.IsValid)
            {
                ps.Add(pointOfProspection);
                ps.Commit();
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
            PointOfProspection pointOfProspection = ps.GetById((long)id);
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
        public ActionResult Edit([Bind(Include = "IdPointOfProspection,Type,name,lat,lon")] PointOfProspection pointOfProspection)
        {
            if (ModelState.IsValid)
            {
                ps.Update(pointOfProspection.IdPointOfProspection, pointOfProspection);
                ps.Commit();
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
            PointOfProspection pointOfProspection = ps.GetById((long)id);
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
            PointOfProspection pointOfProspection = ps.GetById((long)id);
            ps.Delete(pointOfProspection);
            ps.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
            base.Dispose(disposing);
        }
    }
}
