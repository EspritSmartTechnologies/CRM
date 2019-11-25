using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Data;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Services;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Web.Controllers
{
    public class ForumController : Controller
    {
        private PostService ps { get; set; }
        protected DBContext Context { get; set; }
        

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public ForumController()
        {
            this.ps = new PostService();
            this.Context = new DBContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.Context));

        }

        public ActionResult chat()
        {
            return View();
        }

        // GET: Forum
        [Route("Forum")]
        public ActionResult Index(string query)
        {
            if(query != null)
                return View(ps.GetInclude(filter:x=>(x.Title.Contains(query) || x.Content.Contains(query) || x.User.UserName.Contains(query)) ,includes: x => x.User));
            return View(ps.GetInclude(includes: x=>x.User));
        }

        // GET: Forum/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {

            ViewBag.user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System.Linq.Expressions.Expression<System.Func<Post, object>>[] exp = new System.Linq.Expressions.Expression<Func<Post, object>>[3];//x => x.Comments;//new List<System.Linq.Expressions.Expression>();
            exp[0] = x => x.Comments;
            exp[1] = x => x.User;
            exp[2] = x => x.Reacts;

            Post post = ps.GetInclude(filter: x => x.IdPost == id, includes: exp).First();
            System.Linq.Expressions.Expression<System.Func<Comment, object>>[] exp2 = new System.Linq.Expressions.Expression<Func<Comment, object>>[2];//x => x.Comments;//new List<System.Linq.Expressions.Expression>();
            exp2[0] = x => x.Reacts;
            exp2[1] = x => x.User;
            CommentService cs = new CommentService();
            ViewBag.comments = cs.GetInclude(filter: x=>x.PostId == id,includes:exp2);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Forum/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IdPost,Title,Content")] Post post, [Bind(Include = "file")]HttpPostedFileBase file)
        {
            post.PostDate = DateTime.Now;

            post.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (file.ContentLength > 0)
            {
                post.Image = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/uploads"), post.Image);
                file.SaveAs(path);
            }
            if (ModelState.IsValid)
            {
                ps.Add(post);
                ps.Commit();
                return RedirectToAction("Index");
            }

            return View(post);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Details([Bind(Include = "IdPost")] int id, [Bind(Include = "Content")]string content)
        {
            //PostService ps = new PostService();
            System.Linq.Expressions.Expression<System.Func<Post, object>>[] exp = new System.Linq.Expressions.Expression<Func<Post, object>>[2];//x => x.Comments;//new List<System.Linq.Expressions.Expression>();
            exp[0] = x => x.Comments;
            exp[1] = x => x.User;

            Post post = ps.GetInclude(filter: x => x.IdPost == id, includes: exp).First();
            CommentService cs = new CommentService();
            Comment c = new Comment() { PostId = id, Content = content, PostDate = DateTime.Now };
            c.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            cs.Add(c);
            cs.Commit();
            ViewBag.user = System.Web.HttpContext.Current.User.Identity.GetUserId();

            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Comment([Bind(Include = "IdPost")] int id, [Bind(Include = "Content")]string content, [Bind(Include = "IdComment")]int IdComment)
        {
            //PostService ps = new PostService();
            System.Linq.Expressions.Expression<System.Func<Post, object>>[] exp = new System.Linq.Expressions.Expression<Func<Post, object>>[2];//x => x.Comments;//new List<System.Linq.Expressions.Expression>();
            exp[0] = x => x.Comments;
            exp[1] = x => x.User;

            Post post = ps.GetInclude(filter: x => x.IdPost == id, includes: exp).First();
            CommentService cs = new CommentService();
            Comment c = cs.GetById((long)IdComment);//new Comment() { PostId = id,IdComment=IdComment, Content = content, PostDate = DateTime.Now };
            c.Content = content;               
            c.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            cs.Update(c.IdComment, c);
            cs.Commit();


            return RedirectToAction("Details", new { id = id });
        }

        // GET: Forum/Edit/5
        [Route("Forum/Post/Edit")]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = ps.GetById((long)id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Forum/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Forum/Post/Edit")]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IdPost,Title,Content")] Post postt, [Bind(Include = "file")]HttpPostedFileBase file)
        {
            Post post = ps.GetInclude(filter: x => x.IdPost == postt.IdPost).First();
            
                if (file.ContentLength > 0)
            {
                post.Image = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/uploads"), post.Image);
                file.SaveAs(path);
            }
                post.Content = postt.Content;
                ps.Update(post.IdPost,post);
                ps.Commit();
            return RedirectToAction("Details", new { id = post.IdPost });
        }

        // GET: Forum/Delete/5
        [Route("Forum/Post/Delete")]
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = ps.GetById((long)id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Forum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Forum/Post/Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = ps.GetById((long)id);
            ps.Delete(post);
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

        // POST: Comments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCom([Bind(Include = "IdCommentaire")]int IdCommentaire)
        {
            CommentService cs = new CommentService();
            Comment comment = cs.GetInclude(filter: x=>x.IdComment == IdCommentaire, includes: x=>x.Post).First();
            int id = comment.Post.IdPost;
             comment = cs.GetById((long)IdCommentaire);
            cs.Delete(comment);
            cs.Commit();

            ViewBag.user = System.Web.HttpContext.Current.User.Identity.GetUserId();

            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeReact([Bind(Include = "typeReact")]int typeReact, [Bind(Include = "idPost")]int idPost, [Bind(Include = "idComment")]int? idComment)
        {
            try
            {
                React react = new React();
                ReactService rs = new ReactService();
                var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
                ViewBag.user = user;
                if (idComment != null)
                {

                    React r = rs.GetInclude(filter: x => x.UserId == user && x.IdCommentaire == idComment).FirstOrDefault();
                    if (r != null)
                    {
                        react.IdReact = r.IdReact;
                        react.UserId = user;
                        react.IdCommentaire = idComment;
                        if (typeReact == 1)
                            react.Type = ReactType.Downvote;
                        else
                            react.Type = ReactType.Upvote;
                        rs.Update(react.IdReact, react);
                    }
                    else
                    {
                        react.UserId = user;
                        react.IdCommentaire = idComment;
                        if (typeReact == 1)
                            react.Type = ReactType.Downvote;
                        else
                            react.Type = ReactType.Upvote;
                        rs.Add(react);
                    }
                }
                else
                {
                    React r = rs.GetInclude(filter: x => x.UserId == user && x.IdPost == idPost).FirstOrDefault();
                    if (r != null)
                    {
                        react.IdReact = r.IdReact;
                        react.UserId = user;
                        react.IdPost = idPost;
                        if (typeReact == 1)
                            react.Type = ReactType.Downvote;
                        else
                            react.Type = ReactType.Upvote;
                        rs.Update(react.IdReact, react);
                    }
                    else
                    {
                        react.UserId = user;
                        react.IdPost = idPost;
                        if (typeReact == 1)
                            react.Type = ReactType.Downvote;
                        else
                            react.Type = ReactType.Upvote;
                        rs.Add(react);
                    }
                }

                rs.Commit();
                react = rs.GetInclude(includes: xx => xx.User).Last();
                //mail
                //if (!react.User.Trophies.Contains("comment")) { 
                    try
                    {
                        MailMessage mail = new MailMessage("malek.ferchichi@esprit.tn", react.User.Email);
                        mail.Subject = "CRM Trophy";
                        mail.Body = "You just received a new trophy : Reacts King";
                        
                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                        
                        smtpClient.Credentials = new System.Net.NetworkCredential("jawhar.hamitouche@esprit.tn", "Mallaana007");
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
                        body: "You just received a new trophy : Reacts King");
                    
               // }
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("Details", new { id = idPost });
            
        }
    }
}
