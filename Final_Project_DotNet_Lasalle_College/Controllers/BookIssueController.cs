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
    public class BookIssueController : Controller
    {
        private Final_Library_management_LasalleCollegeEntities db = new Final_Library_management_LasalleCollegeEntities();

        // GET: BookIssue
        public ActionResult Index()
        {
            var issueBooks = db.IssueBooks.Include(i => i.BookInfo).Include(i => i.MemberInfo);
            return View(issueBooks.ToList());
        }

        // GET: BookIssue/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            return View(issueBook);
        }

        // GET: BookIssue/Create
        public ActionResult Create()
        {
            Authenticate("BookIssue/Create");
            ViewBag.b_id = new SelectList(db.BookInfoes, "b_id", "b_name");
            ViewBag.m_id = new SelectList(db.MemberInfoes, "id", "name");
            return View();
        }

        // POST: BookIssue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,m_id,b_id,Date")] IssueBook issueBook)
        {
            if (ModelState.IsValid)
            {
                db.IssueBooks.Add(issueBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.b_id = new SelectList(db.BookInfoes, "b_id", "b_name", issueBook.b_id);
            ViewBag.m_id = new SelectList(db.MemberInfoes, "id", "name", issueBook.m_id);
            return View(issueBook);
        }

        // GET: BookIssue/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.b_id = new SelectList(db.BookInfoes, "b_id", "b_name", issueBook.b_id);
            ViewBag.m_id = new SelectList(db.MemberInfoes, "id", "name", issueBook.m_id);
            return View(issueBook);
        }

        // POST: BookIssue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,m_id,b_id,Date")] IssueBook issueBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issueBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.b_id = new SelectList(db.BookInfoes, "b_id", "b_name", issueBook.b_id);
            ViewBag.m_id = new SelectList(db.MemberInfoes, "id", "name", issueBook.m_id);
            return View(issueBook);
        }

        // GET: BookIssue/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            return View(issueBook);
        }

        // POST: BookIssue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IssueBook issueBook = db.IssueBooks.Find(id);
            db.IssueBooks.Remove(issueBook);
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
