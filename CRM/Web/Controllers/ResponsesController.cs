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
    public class ResponsesController : Controller
    {
        
        private ResponseService rs = new ResponseService();

        // GET: Responses
        public ActionResult Index()
        {
            return View(rs.GetAll().ToList());
        }

        // GET: Responses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Response response = rs.GetById((long)id);

            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // GET: Responses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Responses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdResponse,ResponseDate,Content")] Response response)
        {
            if (ModelState.IsValid)
            {
             
                rs.Add(response);
                rs.Commit();
                return RedirectToAction("Index");
            }

            return View(response);
        }

        // GET: Responses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Response response = rs.GetById((long)id);
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // POST: Responses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdResponse,ResponseDate,Content")] Response response)
        {
            if (ModelState.IsValid)
            {
                rs.Update(response.IdResponse, response);
                rs.Commit();
                return RedirectToAction("Index");
            }
            return View(response);
        }

        // GET: Responses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Response response = rs.GetById((long)id);
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Response response = rs.GetById((long)id);
            rs.Delete(response);
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
