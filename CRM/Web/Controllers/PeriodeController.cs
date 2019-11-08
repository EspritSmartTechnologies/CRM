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
    public class PeriodeController : Controller
    {


        IDatabaseFactory dbf;
        IUnitOfWork uow;
        IService<Periode> serPeriode;

        public PeriodeController()
        {
            dbf = new DatabaseFactory();
            uow = new UnitOfWork(dbf);
            serPeriode = new Service<Periode>(uow);
        }

        // GET: Periode
        public ActionResult Index()
        {
            List<Periode> lst = serPeriode.GetAll().ToList<Periode>();
            return View(lst);
        }

        // GET: Periode/Details/5
        public ActionResult Details(int id)
        {
            Periode p = serPeriode.GetById(id);
            return View(p);
        }

        // GET: Periode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Periode/Create
        [HttpPost]
        public ActionResult Create(Periode p, FormCollection collection)
        {
            try
            {
                serPeriode.Add(p);
                serPeriode.Commit();
                // TODO: Add insert logic here
                uow.Dispose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(p);
            }
        }

        // GET: Periode/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Periode p = serPeriode.GetById(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: Periode/Edit/5
        [HttpPost]
        public ActionResult Edit(Periode p, FormCollection collection)
        {
            try
            {

                serPeriode.Update(p);
                serPeriode.Commit();
                uow.Dispose();
                return RedirectToAction("Index");
            }
            catch
            {

                return View(p);
            }
        }


        // GET: Periode/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periode p = serPeriode.GetById(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: Periode/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Periode p = serPeriode.GetById(id);
            try
            {

                serPeriode.Delete(p);
                serPeriode.Commit();
                uow.Dispose();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(p);
            }

        }
    }
}