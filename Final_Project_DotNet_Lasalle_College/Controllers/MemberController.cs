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
    public class MemberController : Controller
    {
        private Final_Library_management_LasalleCollegeEntities db = new Final_Library_management_LasalleCollegeEntities();

        // GET: Member
        public ActionResult Index()
        {
            return View(db.MemberInfoes.ToList());
        }

        // GET: Member/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInfo memberInfo = db.MemberInfoes.Find(id);
            if (memberInfo == null)
            {
                return HttpNotFound();
            }
            return View(memberInfo);
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            Authenticate("Member/Create");
            return View();
        }

        // POST: Member/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,address")] MemberInfo memberInfo)
        {
            if (ModelState.IsValid)
            {
                db.MemberInfoes.Add(memberInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memberInfo);
        }

        // GET: Member/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInfo memberInfo = db.MemberInfoes.Find(id);
            if (memberInfo == null)
            {
                return HttpNotFound();
            }
            return View(memberInfo);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,address")] MemberInfo memberInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memberInfo);
        }

        // GET: Member/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInfo memberInfo = db.MemberInfoes.Find(id);
            if (memberInfo == null)
            {
                return HttpNotFound();
            }
            return View(memberInfo);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberInfo memberInfo = db.MemberInfoes.Find(id);
            db.MemberInfoes.Remove(memberInfo);
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
