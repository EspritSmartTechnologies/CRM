using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Entities;
using Services;

namespace Web.Controllers
{
    public class AgentsController : Controller
    {
        private AgentService ass = new AgentService();

        // GET: Agents
        public ActionResult Index()
        {
            return View(ass.GetAll());
        }

        // GET: Agents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = ass.GetById((long)id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        // GET: Agents/Create
        public ActionResult Create()
        {
            PointofprospectionService pps = new PointofprospectionService();
            IEnumerable<PointOfProspection> pss = pps.GetAll();
            ViewBag.points = pss;
            return View();
        }

        // POST: Agents/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAgent,FullName,IdPointOfProdpection")] Agents agents)
        {
            PointofprospectionService pps = new PointofprospectionService();
            IEnumerable<PointOfProspection> pss = pps.GetAll();
            ViewBag.points = pss;
            if (ModelState.IsValid)
            {
                ass.Add(agents);
                ass.Commit();
                return RedirectToAction("Index");
            }

            return View(agents);
        }

        // GET: Agents/Edit/5
        public ActionResult Edit(int? id)
        {
            PointofprospectionService pps = new PointofprospectionService();
            IEnumerable<PointOfProspection> pss = pps.GetAll();
            ViewBag.points = pss;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = ass.GetById((long)id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        // POST: Agents/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAgent,FullName,IdPointOfProdpection")] Agents agents)
        {
            PointofprospectionService pps = new PointofprospectionService();
            IEnumerable<PointOfProspection> pss = pps.GetAll();
            ViewBag.points = pss;
            if (ModelState.IsValid)
            {
                ass.Update(agents.IdAgent, agents);
                return RedirectToAction("Index");
            }
            return View(agents);
        }

        // GET: Agents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = ass.GetById((long)id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agents agents = ass.GetById((long)id);
            ass.Delete(agents);
            ass.Commit();
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
