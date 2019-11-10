using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Data;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Services;

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
        // GET: Forum
        [Route("Forum")]
        public ActionResult Index()
        {
            return View(ps.GetInclude(filter: x=>x.User.Email == "jawhar.hamitouche@esprit.tn",includes: x=>x.User));
        }

        // GET: Forum/Details/5
        [Route("Forum/Post")]
        public ActionResult Details(int? id)
        {

            ViewBag.user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System.Linq.Expressions.Expression<System.Func<Post, object>>[] exp = new System.Linq.Expressions.Expression<Func<Post, object>>[2];//x => x.Comments;//new List<System.Linq.Expressions.Expression>();
            exp[0] = x => x.Comments;
            exp[1] = x => x.User;

            Post post = ps.GetInclude(filter: x => x.IdPost == id, includes: exp).First();
            
            CommentService cs = new CommentService();
            ViewBag.comments = cs.GetInclude(filter: x=>x.PostId == id,includes:x=>x.User);
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
    }
}
