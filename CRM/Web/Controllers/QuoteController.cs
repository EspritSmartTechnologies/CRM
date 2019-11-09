using Data.Infrastructure;
using Domain.Entities;
using Rotativa;
using Service.Pattern;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class QuoteController : Controller
    {

        IDatabaseFactory dbf;
        IUnitOfWork uow;
        IService<Quote> servQuote;

        public string message = "";
        public string subject = "demande devis envoyé";

        public QuoteController()
        {
            dbf = new DatabaseFactory();
            uow = new UnitOfWork(dbf);
            servQuote = new Service<Quote>(uow);
        }


        public ActionResult Details22()
        {
            return new ActionAsPdf("Index")
            {
                FileName = Server.MapPath("~/Content/Quota.pdf")
            };
        }
        // GET: Quote
        public ActionResult Index()
        {
            var Quote1 = servQuote.GetMany();
            return View(Quote1);
        }

        // GET: Quote/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote Q = servQuote.GetById(id);
            if (Q == null)
            {
                return HttpNotFound();
            }
            return View(Q);
        }

        // GET: Quote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quote/Create
        [HttpPost]
        public ActionResult Create(QuoteModel Q)
        {
            try
            {
                // TODO: Add insert logic here
                Quote p = new Quote();

                p.nom = Q.nom;
                p.Senddate = Q.Senddate;
                p.prenom = Q.prenom;
                p.description = Q.description;
                p.mail = Q.mail;


               
                var senderemail = new MailAddress("wissem.khoufi@esprit.tn", "validation Demande");
                var recieveremail = new MailAddress("wissem.khoufi@esprit.tn", "Reciever");
                var password = "taraji9acem222";

                message = "Bonjour, " + "\n" + "votre suivi a ete ajouter avec succé ! " + "\n" +
                " " + "\n" + "Nouvelle Evaluation : " + p.nom + "\n" +

                " " + "\n" + "Nouveau Entretient : " + p.prenom + "\n" +

                " " + "\n" + "Nouvelle Date : " + p.Senddate + "\n" +

                " " + "\n" + "" + "\n" + "cordialement ";
                var sub = subject;
                var body = message;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderemail.Address, password)
                };
                using (var mess = new MailMessage(senderemail, recieveremail)
                {
                    Subject = subject,
                    Body = body
                }
                    )
                {
                    smtp.Send(mess);
                }


                servQuote.Add(p);
                servQuote.Commit();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Quote/Edit/5
        public ActionResult Edit(int id)
        {
            Quote p = servQuote.GetById(id);

            //    Domain.Entities.employe cat = se.GetById(id);

            Models.QuoteModel pm = new Models.QuoteModel();


            var congeModel = new Models.QuoteModel
            {
                QuoteId = p.QuoteId,
                mail = p.mail,
                description = p.description,
                prenom = p.prenom,
                nom = p.nom,
                Senddate = p.Senddate,
                

            };

           

            
            return View(congeModel);
        }

        // POST: Quote/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,  Models.QuoteModel congemodel)
        {
            try
            {
                var conge = servQuote.GetMany().Where(c => c.QuoteId.Equals(id)).FirstOrDefault();

                // TODO: Add update logic here
                conge.QuoteId = congemodel.QuoteId;
                conge.nom = congemodel.nom;
                conge.prenom = congemodel.prenom;
                conge.Senddate = congemodel.Senddate;
                conge.mail = congemodel.mail;
                conge.description = congemodel.description;




                servQuote.Update(conge);



                servQuote.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quote/Delete/5
       
    }
}
