using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WedMarch9.Models;
using PagedList;
using PagedList.Mvc;

namespace WedMarch9.Controllers
{
    [RequireHttps]

    public class BlogPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BlogPosts
        public ActionResult Index(int? page, string query)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.Query = query;
            var qposts = db.Posts.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query))
            {
                qposts = qposts.Where(p => p.Title.Contains(query) || p.Body.Contains(query) || p.Comments.Any(c => c.Body.Contains(query)));
            }
            var posts = qposts.OrderByDescending(p => p.Created).ToPagedList(pageNumber, pageSize);
            return View(posts);
        }


        // POST: 
        //[HttpPost]
        //public ActionResult SLUG()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var Slug -StringUtilities.URLFriendly(post.Title);
        //        if (String.IsNullOrWhiteSpace(Slug))
        //        {
        //            ModelState.AddModelError("Title", "The title must be unique.");
        //            return View(post);
        //        }
        //        if (db.Posts.Any(p->p.Slug-- Slug))
        //        {
        //            ModelState.AddModelError("Title", "The title must be unique.");
        //            return View(post);
        //        }

        //        return View(blogPosts);
        //    }
        //    BlogPosts.Slug - Slug;
        //    db.Posts.Add(post);
        //    db.SaveChanges();
        //}


        // GET: BlogPosts/Details/5
        public ActionResult Details(string slug)
        {
            if (String.IsNullOrWhiteSpace(slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPosts blogPosts = db.Posts.FirstOrDefault(p => p.Slug == slug);
            if (blogPosts == null)
            {
                return HttpNotFound();
            }
            return View(blogPosts);
        }

        //GET: BlogPosts/Admin
        public ActionResult Admin()
        {
            return View(db.Posts.ToList());
        }

        // GET: BlogPosts/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //POST: BlogPosts/CreateComment
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "PostId, Body")]Comment comment)
        {

            var post = db.Posts.Find(comment.PostId);
            var Slug = post.Slug;

            if (ModelState.IsValid)
            {
                comment.AuthorId = User.Identity.GetUserId();
                comment.Created = DateTimeOffset.Now;
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { slug = Slug});
        }

        //public class ImageUploadValidator
        //{
        //    public static bool IsWebFriendlyImage(HttpPostedFileBase file)
        //    {
        //        //check for actual object
        //        if (file == null) return false;

        //        //check the size of a file - must be less than 2mb and greather than 1k
        //        if (file.ContentLength > 2 * 1024 * 1024 || file.ContentLength < 1024) return false;

        //        try
        //        {
        //            using (var img = Image.FromStream(file.InputStream))
        //            {
        //                return ImageFormat.Jpeg.Equals(img.RawFormat) || ImageFormat.Png.Equals(img.RawFormat) || ImageFormat.Gif.Equals(img.RawFormat);
        //            }
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }

        //}

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Slug,Body,MediaUrl")] BlogPosts blogPosts, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                //restricting the valid file formats to only images
                if (ImageUploadValidator.IsWebFriendlyImage(image))
                {
                    var fileName = Path.GetFileName(image.FileName);
                    image.SaveAs(Path.Combine(Server.MapPath("~/img/blogposts/"), fileName));
                    blogPosts.MediaUrl = "~/img/blogposts/" + fileName;
                }
                var Slug = StringUtilities.URLFriendly(blogPosts.Title);
                if (String.IsNullOrWhiteSpace(Slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique.");
                    return View(blogPosts);
                }
                if (db.Posts.Any(p=>p.Slug== Slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique.");
                    return View(blogPosts);
                }

                blogPosts.Slug = Slug;
                
                blogPosts.Created = DateTimeOffset.Now;
                db.Posts.Add(blogPosts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogPosts);
        }

        // GET: BlogPosts/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPosts blogPosts = db.Posts.Find(id);
            if (blogPosts == null)
            {
                return HttpNotFound();
            }
            return View(blogPosts);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Slug,Body,MediaUrl,Published")] BlogPosts blogPosts, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (ImageUploadValidator.IsWebFriendlyImage(image))
                {
                    var fileName = Path.GetFileName(image.FileName);
                    image.SaveAs(Path.Combine(Server.MapPath("~/img/blogposts/"), fileName));
                    blogPosts.MediaUrl = "~/img/blogposts/" + fileName;
                    db.Entry(blogPosts).Property("MediaUrl").IsModified = true;
                }
                blogPosts.Updated = DateTimeOffset.Now;

                db.Posts.Attach(blogPosts);
                db.Entry(blogPosts).Property("Title").IsModified = true;
                db.Entry(blogPosts).Property("Body").IsModified = true;
                db.Entry(blogPosts).Property("Updated").IsModified = true;

                //db.Entry(blogPosts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPosts);
        }

        // GET: BlogPosts/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPosts blogPosts = db.Posts.Find(id);
            if (blogPosts == null)
            {
                return HttpNotFound();
            }
            return View(blogPosts);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPosts blogPosts = db.Posts.Find(id);
            db.Posts.Remove(blogPosts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
