using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Web.Models;
using Services;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductService ps = new ProductService();

        public long IdProduct { get; private set; }


        // GET: Product
        public ActionResult Index()
        {
            return View(ps.GetAll().ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductService product = ps.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            CategoryService cs = new CategoryService();
            ViewBag.cats = cs.GetAll();
            return View(); 
        }


        // POST: Product/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduct,Colour,Quantity,Category,Price,PointOfSale,IdCategory")] Product product)
        {
            CategoryService cs = new CategoryService();
            product.Category = cs.GetById(Convert.ToInt32(product.IdCategory));
            if (ModelState.IsValid)
            {
                ps.Add(product);
                ps.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductService product = ps.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduct,Colour,Quantity,Category,Price,PointOfSale")] Product product)
        {
            if (ModelState.IsValid)
            {
                ps.Update(product.IdProduct, product);
                ps.Commit();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductService product = ps.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductService product = ps.GetById(id);
            ps.Delete(product);
            ps.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
            base.Dispose(disposing);
        }



        public ActionResult ColumnChart()
        {
            return View();
        }

        /*
        public ActionResult ExamPerformanceChart(string Produit, string month2)
        {
            int marks = 0;
            DbContext ams = new DbContext("MyContext");
            DateTime month2Value = Convert.ToDateTime(month2);
            var getResults = (from d in ams.Products
                            
                              where d.GetIdProduct == Produit && d.Date.Value.Month == month2Value.Month
                && d.Date.Value.Year == month2Value.Year
                              select d).ToList();
            List<Product> result = new List<Product>();
            foreach (var item in getResults)
            {
                if (item.MarksObtained == "A")
                {
                    marks = 0;
                }
                else if (item.MarksObtained != "A")
                {
                    marks = Convert.ToInt32(item.MarksObtained);
                }
                result.Add(new StudentResult()
                {
                    //examDate = item.Date.Value.Date,
                    obtainedMarks = marks,
                    score = Convert.ToInt32(item.Score),
                    subjectName = item.SubjectName
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }*/
    }

    


}
