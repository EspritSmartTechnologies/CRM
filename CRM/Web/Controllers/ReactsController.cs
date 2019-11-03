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
    public class ReactsController : Controller
    {
        private ReactService rs= new ReactService();

        // GET: Reacts
        public ActionResult Index()
        {
            return View(rs.GetAll());
        }

        // GET: Reacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            React react = rs.GetById((long)id);
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
                rs.Add(react);
                rs.Commit();
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
            React react = rs.GetById((long)id);
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
                rs.Update(react.IdReact, react);
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
            React react = rs.GetById((long)id);
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
            React react = rs.GetById((long)id);
            rs.Delete(react);
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
