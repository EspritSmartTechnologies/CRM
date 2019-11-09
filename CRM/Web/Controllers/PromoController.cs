using Data.Infrastructure;
using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PromoController : Controller
    {

        IDatabaseFactory dbf;
        IUnitOfWork uow;
        IService<Promotion> serPromo;
        IService<ZoneGeographique> serZone;
        IService<Periode> serPer;
        public PromoController()
        {
            dbf = new DatabaseFactory();
            uow = new UnitOfWork(dbf);
            serPromo = new Service<Promotion>(uow);
            serZone = new Service<ZoneGeographique>(uow);
            serPer = new Service<Periode>(uow);
        }

        // GET: Promo
        public ActionResult Index()
        {
            List<Promotion> lst = serPromo.GetAll().ToList<Promotion>();
            foreach (var promo in lst)
            {
                promo.zone = serZone.GetById(promo.Zone_Id);
            }

            foreach (var promo in lst)
            {
                promo.periode = serPer.GetById(promo.periode_Id);
            }

            return View(lst);
        }

        // GET: Promo/Details/5
        public ActionResult Details(int id)
        {
            Promotion p = serPromo.GetById(id);
            p.periode = serPer.GetById(p.periode_Id);
            p.zone = serZone.GetById(p.Zone_Id);
            return View(p);
        }

        // GET: Promo/Create
        public ActionResult Create()
        {
            ViewBag.periode_Id = new SelectList(dbf.DataContext.Periodes, "id", "saison");
            ViewBag.Zone_Id = new SelectList(dbf.DataContext.Zones, "Id", "gouvernorat");
            return View();
        }

        // POST: Promo/Create
        [HttpPost]
        public ActionResult Create(Promotion p, FormCollection collection,HttpPostedFileBase UploadImage)
        {
            try
            {
                if (UploadImage != null) {
                    if (UploadImage.ContentType == "image/jpg" ||
                        UploadImage.ContentType == "image/png" ||
                        UploadImage.ContentType == "image/bmp" ||
                        UploadImage.ContentType == "image/gif" ||
                        UploadImage.ContentType == "image/jpeg")
                    { 
                        UploadImage.SaveAs(Server.MapPath("/")+ "/Image/" + UploadImage.FileName);
                        p.ImageURL = UploadImage.FileName;
                    }

                    else return View();
                }
                else return View();

                //string fileName = Path.GetFileNameWithoutExtension(p.ImageFile.FileName);
                //string extension = Path.GetExtension(p.ImageFile.FileName);
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //p.ImagePath = "~/Image/" + fileName;
                //fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                //p.ImageFile.SaveAs(fileName);
                serPromo.Add(p);
                serPromo.Commit();
                // TODO: Add insert logic here
                uow.Dispose();
                return RedirectToAction("Index");
            }
            catch
            {

                return View(p);
            }
        }

        // GET: Promo/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Promotion p = serPromo.GetById(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            ViewBag.periode_Id = new SelectList(dbf.DataContext.Periodes, "id", "saison");
            ViewBag.Zone_Id = new SelectList(dbf.DataContext.Zones, "Id", "gouvernorat");
            return View(p);
        }

        // POST: Promo/Edit/5
        [HttpPost]
        public ActionResult Edit(Promotion p, FormCollection collection)
        {
            try
            {

                serPromo.Update(p);
                serPromo.Commit();
                uow.Dispose();
                return RedirectToAction("Index");
            }
            catch
            {

                return View(p);
            }
        }

        // GET: Promo/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promotion p = serPromo.GetById(id);
            if (p == null)
            {
                return HttpNotFound();
            }

            p.periode = serPer.GetById(p.periode_Id);
            p.zone = serZone.GetById(p.Zone_Id);
            return View(p);
        }

        // POST: Promo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Promotion p = serPromo.GetById(id);
            try
            {

                serPromo.Delete(p);
                serPromo.Commit();
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
