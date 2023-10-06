using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProExam.Models;

namespace ProExam.Controllers
{
    public class LoginInfoesController : Controller
    {
        private ProExamDBEntities5 db = new ProExamDBEntities5();

        // GET: LoginInfoes
        public ActionResult LoginInfo()
        {
            return View(db.LoginInfoes.ToList());
        }

        // GET: LoginInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginInfo loginInfo = db.LoginInfoes.Find(id);
            if (loginInfo == null)
            {
                return HttpNotFound();
            }
            return View(loginInfo);
        }

        // GET: LoginInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserCode,Password,Email,LastLoginDate")] LoginInfo loginInfo)
        {
            if (ModelState.IsValid)
            {
                db.LoginInfoes.Add(loginInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginInfo);
        }

        // GET: LoginInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginInfo loginInfo = db.LoginInfoes.Find(id);
            if (loginInfo == null)
            {
                return HttpNotFound();
            }
            return View(loginInfo);
        }

        // POST: LoginInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserCode,Password,Email,LastLoginDate")] LoginInfo loginInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginInfo);
        }

        // GET: LoginInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginInfo loginInfo = db.LoginInfoes.Find(id);
            if (loginInfo == null)
            {
                return HttpNotFound();
            }
            return View(loginInfo);
        }

        // POST: LoginInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoginInfo loginInfo = db.LoginInfoes.Find(id);
            db.LoginInfoes.Remove(loginInfo);
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
