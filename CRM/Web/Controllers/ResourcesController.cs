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
    public class ResourcesController : Controller
    {
        private ResourcesService rs = new ResourcesService();

        // GET: Resources
        public ActionResult Index()
        {
            return View(rs.GetAll().ToList());
        }

        // GET: Resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resources resources = rs.GetById((long)id);
            if (resources == null)
            {
                return HttpNotFound();
            }
            return View(resources);
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdResource,Quantity,Name")] Resources resources)
        {
            if (ModelState.IsValid)
            {
                rs.Add(resources);
                rs.Commit();
                return RedirectToAction("Index");
            }

            return View(resources);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resources resources = rs.GetById((long)id);
            if (resources == null)
            {
                return HttpNotFound();
            }
            return View(resources);
        }

        // POST: Resources/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdResource,Quantity,Name")] Resources resources)
        {
            if (ModelState.IsValid)
            {
                rs.Update(resources.IdResource, resources);
                return RedirectToAction("Index");
            }
            return View(resources);
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resources resources = rs.GetById((long)id);
            if (resources == null)
            {
                return HttpNotFound();
            }
            return View(resources);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resources resources = rs.GetById((long)id);
            rs.Delete(resources);
            rs.Commit();
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
