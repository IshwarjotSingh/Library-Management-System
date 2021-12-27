using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project_DotNet_Lasalle_College;

namespace Final_Project_DotNet_Lasalle_College.Controllers
{
    public class BookInfoController : Controller
    {
        private Final_Library_management_LasalleCollegeEntities db = new Final_Library_management_LasalleCollegeEntities();

        // GET: BookInfo
        public ActionResult Index()
        {
            var bookInfoes = db.BookInfoes.Include(b => b.author).Include(b => b.category).Include(b => b.publisher);
            return View(bookInfoes.ToList());
        }

        // GET: BookInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInfo bookInfo = db.BookInfoes.Find(id);
            if (bookInfo == null)
            {
                return HttpNotFound();
            }
            return View(bookInfo);
        }

        // GET: BookInfo/Create
        public ActionResult Create()
        {
            Authenticate("BookInfo/Create");


            ViewBag.aut_id = new SelectList(db.authors, "id", "name");
            ViewBag.cat_id = new SelectList(db.categories, "id", "cat_name");
            ViewBag.pub_id = new SelectList(db.publishers, "id", "name");
            return View();
        }

        // POST: BookInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "b_id,b_name,aut_id,pub_id,cat_id,pages")] BookInfo bookInfo)
        {
            Authenticate("Bookinfo/Controller");
            if (ModelState.IsValid)
            {
                db.BookInfoes.Add(bookInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aut_id = new SelectList(db.authors, "id", "name", bookInfo.aut_id);
            ViewBag.cat_id = new SelectList(db.categories, "id", "cat_name", bookInfo.cat_id);
            ViewBag.pub_id = new SelectList(db.publishers, "id", "name", bookInfo.pub_id);
            return View(bookInfo);
        }

        // GET: BookInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInfo bookInfo = db.BookInfoes.Find(id);
            if (bookInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.aut_id = new SelectList(db.authors, "id", "name", bookInfo.aut_id);
            ViewBag.cat_id = new SelectList(db.categories, "id", "cat_name", bookInfo.cat_id);
            ViewBag.pub_id = new SelectList(db.publishers, "id", "name", bookInfo.pub_id);
            return View(bookInfo);
        }

        // POST: BookInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "b_id,b_name,aut_id,pub_id,cat_id,pages")] BookInfo bookInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aut_id = new SelectList(db.authors, "id", "name", bookInfo.aut_id);
            ViewBag.cat_id = new SelectList(db.categories, "id", "cat_name", bookInfo.cat_id);
            ViewBag.pub_id = new SelectList(db.publishers, "id", "name", bookInfo.pub_id);
            return View(bookInfo);
        }

        // GET: BookInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInfo bookInfo = db.BookInfoes.Find(id);
            if (bookInfo == null)
            {
                return HttpNotFound();
            }
            return View(bookInfo);
        }

        // POST: BookInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookInfo bookInfo = db.BookInfoes.Find(id);
            db.BookInfoes.Remove(bookInfo);
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
        private void Authenticate(string returnUrl)
        {
            HttpCookie cookie = Request.Cookies["AuthCookie"];
            if (cookie == null)
            {
                Response.Redirect("/Login/Index?ReturnUrl=" + returnUrl,false);
            }
        }
    }
}
