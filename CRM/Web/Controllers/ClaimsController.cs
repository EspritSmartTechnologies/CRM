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
    public class ClaimsController : Controller
    {
        private ClaimsService cs = new ClaimsService();

        // GET: Claims
        public ActionResult Index()
        {
            return View(cs.GetAll().ToList());
        }

        // GET: Claims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = cs.GetById((long)id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // GET: Claims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Claims/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdClaim,Type,State,Date,Content")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                cs.Add(claim);
                cs.Commit();
                return RedirectToAction("Index");
            }

            return View(claim);
        }

        // GET: Claims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = cs.GetById((long)id); 
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: Claims/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdClaim,Type,State,Date,Content")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                cs.Update(claim.IdClaim, claim);
                cs.Commit();
                return RedirectToAction("Index");
            }
            return View(claim);
        }

        // GET: Claims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = cs.GetById((long)id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Claim claim = cs.GetById((long)id);
            cs.Delete(claim);
            cs.Commit();
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
