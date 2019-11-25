using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Services;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Web.Controllers
{
    public class ClaimController : Controller
    {
        private ClaimsService cs = new ClaimsService();

        // GET: Claim
        //recuperation de toutes les rec de ce user index
        public ActionResult Index()
        {
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            return View(cs.GetInclude(filter:x=>x.userId == user));
        }

        // GET: Claim/Details/5
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
            ResponseService rs = new ResponseService();
            List<Response> lr = rs.GetInclude(filter: x => x.idClaim == id);
            ViewBag.lr = lr;
            return View(claim);
        }        // GET: Claim/Details/5

        // GET: Claim/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Claim/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdClaim,Type,Content")] Claim claim)
        {
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            claim.userId = user;
            claim.Date = DateTime.Now;
            claim.State = State.Ouverte;
            if (ModelState.IsValid)
            {
                cs.Add(claim);
                cs.Commit();
                return RedirectToAction("Index");
            }

            return View(claim);
        }

        // GET: Claim/Edit/5
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

        // POST: Claim/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdClaim,Type,Content")] Claim claim)
        {
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            claim.userId = user;
            claim.Date = DateTime.Now;
            claim.State = State.EnCours;
            if (ModelState.IsValid)
            {
                cs.Update(claim.IdClaim,claim);
                cs.Commit();
                return RedirectToAction("Index");
            }
            return View(claim);
        }

        // GET: Claim/Delete/5
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

        // POST: Claim/Delete/5
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





        public ActionResult DetailsBack(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = cs.GetById((long)id);
            ResponseService rs = new ResponseService();
            List<Response> lr = rs.GetInclude(filter: x => x.idClaim == id);
            ViewBag.lr = lr;
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }
        public ActionResult IndexBack()
        {
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ResponseService rs = new ResponseService();
            
            return View(cs.GetInclude(includes: x=>x.Responses));
        }

        [HttpPost]
        public ActionResult Reponse(int IdClaim, string text, Response r) {
            Claim c = cs.GetById((long)IdClaim);
            
            c.State = State.Traitée;

            cs.Update(c.IdClaim,c);
            r.Content = text;
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            r.IdUser = user;
            r.ResponseDate = DateTime.Now;
            ResponseService rs = new ResponseService();
            rs.Add(r);
            rs.Commit();
            c = cs.GetInclude(includes: x => x.User, filter: x=>x.IdClaim==IdClaim).First();
            //mail
            try
            {
                MailMessage mail = new MailMessage("malek.ferchichi@esprit.tn", "malek.ferchichi@esprit.tn");
                mail.Subject = "CRM";
                mail.Body = "Votre reclamation a ete traitee ";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("malek.ferchichi@esprit.tn", "07227314");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            //sms
            const string accountSid = "AC127cc5681eb0c7798f01f68f753e657d";
            const string authToken = "4c4f04acab6ecd9f7efd6d9d1290195a";
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber("+12029309654"),
            to: new Twilio.Types.PhoneNumber("+21650334771"),
                body: "Votre reclamation a ete traitee");

            return RedirectToAction("DetailsBack", "Claim", new { id = c.IdClaim });
        }

        [HttpPost]
        public ActionResult Satisfaction(int IdClaim, int satisfaction, Satisfaction r) {
            Claim c = cs.GetById((long)IdClaim);
            if(satisfaction == 0)
            {
                c.State = State.Ouverte;
                cs.Update(c.IdClaim, c);
            }
            //c.State = State.Traitée;

            //cs.Update(c.IdClaim,c);


            r.Level = (Level)satisfaction;
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            r.idUser = user;
            r.IdClaim = IdClaim;
            SatisfactionService rs = new SatisfactionService();
            rs.Add(r);


            rs.Commit();
                
            return RedirectToAction("Details", "Claim", new { id = c.IdClaim });
        }
    }
}
