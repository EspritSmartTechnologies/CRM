﻿using System;
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
    public class PointOfSalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PointOfSales
        public ActionResult Index()
        {
            return View(db.PointOfSales.ToList());
        }

        // GET: PointOfSales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointOfSale pointOfSale = db.PointOfSales.Find(id);
            if (pointOfSale == null)
            {
                return HttpNotFound();
            }
            return View(pointOfSale);
        }

        // GET: PointOfSales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PointOfSales/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPointOfSale,Type,Adress,Phone")] PointOfSale pointOfSale)
        {
            if (ModelState.IsValid)
            {
                db.PointOfSales.Add(pointOfSale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pointOfSale);
        }

        // GET: PointOfSales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointOfSale pointOfSale = db.PointOfSales.Find(id);
            if (pointOfSale == null)
            {
                return HttpNotFound();
            }
            return View(pointOfSale);
        }

        // POST: PointOfSales/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPointOfSale,Type,Adress,Phone")] PointOfSale pointOfSale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pointOfSale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pointOfSale);
        }

        // GET: PointOfSales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointOfSale pointOfSale = db.PointOfSales.Find(id);
            if (pointOfSale == null)
            {
                return HttpNotFound();
            }
            return View(pointOfSale);
        }

        // POST: PointOfSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PointOfSale pointOfSale = db.PointOfSales.Find(id);
            db.PointOfSales.Remove(pointOfSale);
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
