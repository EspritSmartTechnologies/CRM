
using Data.Infrastructure;
using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class QuotaAdminController : Controller
    {
        IDatabaseFactory dbf;
        IUnitOfWork uow;
        IService<Quote> servQuote1;

        public QuotaAdminController()
        {
            dbf = new DatabaseFactory();
            uow = new UnitOfWork(dbf);
            servQuote1 = new Service<Quote>(uow);
        }
        public ActionResult Index()
        {
            var Quote = servQuote1.GetMany();
            return View(Quote);
        }

        // GET: QuotaAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //public ActionResult Details22()
        //{
        //    return new ActionAsPdf("Index")
        //    {
        //        FileName = Server.MapPath("~/Content/Quota.pdf")
        //    };
        //}

        // GET: QuotaAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuotaAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuotaAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuotaAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuotaAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            var Conge = servQuote1.GetMany().Where(c => c.QuoteId.Equals(id)).FirstOrDefault();
            servQuote1.Delete(Conge);
            servQuote1.Commit();
            return RedirectToAction("Index");
        }

        // POST: Quote/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var Conge = servQuote1.GetMany().Where(c => c.QuoteId.Equals(id)).FirstOrDefault();
                servQuote1.Delete(Conge);
                servQuote1.Commit();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public JsonResult GetSearch(string s)
        {
            List<Quote> listerconge = servQuote1.GetMany(c => c.prenom.Contains(s)).ToList<Quote>();

            return new JsonResult { Data = listerconge, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
    }
}
