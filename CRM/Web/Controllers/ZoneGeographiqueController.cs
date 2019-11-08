using Data.Infrastructure;
using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ZoneGeographiqueController : Controller
    {


        IDatabaseFactory dbf;
        IUnitOfWork uow;
        IService<ZoneGeographique> serZone;

        public ZoneGeographiqueController()
        {
            dbf = new DatabaseFactory();
            uow = new UnitOfWork(dbf);
            serZone = new Service<ZoneGeographique>(uow);
        }
        // GET: ZoneGeographique
        public ActionResult Index()
        {
            List<ZoneGeographique> lst = serZone.GetAll().ToList<ZoneGeographique>();
            return View(lst);
        }

        // GET: ZoneGeographique/Details/5
        public ActionResult Details(int id)
        {
            ZoneGeographique zone = serZone.GetById(id);
            return View(zone);
        }

        // GET: ZoneGeographique/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZoneGeographique/Create
        [HttpPost]
        public ActionResult Create(ZoneGeographique zone, FormCollection collection)
        {
            try
            {
                serZone.Add(zone);
                serZone.Commit();
                // TODO: Add insert logic here
                uow.Dispose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(zone);
            }
        }

        // GET: ZoneGeographique/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoneGeographique zone = serZone.GetById(id);
            if (zone == null)
            {
                return HttpNotFound();
            }
            return View(zone);
        }

        // POST: ZoneGeographique/Edit/5
        [HttpPost]
        public ActionResult Edit(ZoneGeographique z, FormCollection collection)
        {
            try
            {

                serZone.Update(z);
                serZone.Commit();
                uow.Dispose();
                return RedirectToAction("Index");
            }
            catch
            {

                return View(z);
            }
        }

        // GET: ZoneGeographique/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoneGeographique z = serZone.GetById(id);
            if (z == null)
            {
                return HttpNotFound();
            }
            return View(z);
        }

        // POST: ZoneGeographique/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ZoneGeographique z = serZone.GetById(id);
            try
            {

                serZone.Delete(z);
                serZone.Commit();
                uow.Dispose();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(z);
            }
        }
    }
}
