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
    public class SatisfactionsController : Controller
    {
        private SatisfactionService ss = new SatisfactionService();

        // GET: Satisfactions
        public ActionResult Index()
        {
            return View(ss.GetAll().ToList());
        }

        // GET: Satisfactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Satisfaction satisfaction = ss.GetById((long)id);
            if (satisfaction == null)
            {
                return HttpNotFound();
            }
            return View(satisfaction);
        }

        // GET: Satisfactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Satisfactions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSatisfaction,Level")] Satisfaction satisfaction)
        {
            if (ModelState.IsValid)
            {
                ss.Add(satisfaction);
                ss.Commit();
                return RedirectToAction("Index");
            }

            return View(satisfaction);
        }

        // GET: Satisfactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Satisfaction satisfaction = ss.GetById((long)id);
            if (satisfaction == null)
            {
                return HttpNotFound();
            }
            return View(satisfaction);
        }

        // POST: Satisfactions/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSatisfaction,Level")] Satisfaction satisfaction)
        {
            if (ModelState.IsValid)
            {
                ss.Update(satisfaction.IdSatisfaction, satisfaction);
                ss.Commit();
                return RedirectToAction("Index");
            }
            return View(satisfaction);
        }

        // GET: Satisfactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Satisfaction satisfaction = ss.GetById((long)id);
            if (satisfaction == null)
            {
                return HttpNotFound();
            }
            return View(satisfaction);
        }

        // POST: Satisfactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Satisfaction satisfaction = ss.GetById((long)id);
            ss.Delete(satisfaction);
            ss.Commit();
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
