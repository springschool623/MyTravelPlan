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
    public class Subjects_StudentController : Controller
    {
        private ProExamDBEntities9 db = new ProExamDBEntities9();

        // GET: Subjects_Student
        public ActionResult Index()
        {
            var subjects_Student = db.Subjects_Student.Include(s => s.Student).Include(s => s.Subject);
            return View(subjects_Student.ToList());
        }

        // GET: Subjects_Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjects_Student subjects_Student = db.Subjects_Student.Find(id);
            if (subjects_Student == null)
            {
                return HttpNotFound();
            }
            return View(subjects_Student);
        }

        // GET: Subjects_Student/Create
        public ActionResult Create()
        {
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentCode");
            ViewBag.Subject_ID = new SelectList(db.Subjects, "Subject_ID", "Subject_Name");
            return View();
        }

        // POST: Subjects_Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Subs_Stu_No,StudentCode,Subject_ID")] Subjects_Student subjects_Student)
        {
            if (ModelState.IsValid)
            {
                db.Subjects_Student.Add(subjects_Student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "Stu_FirstName", subjects_Student.StudentCode);
            ViewBag.Subject_ID = new SelectList(db.Subjects, "Subject_ID", "Subject_Name", subjects_Student.Subject_ID);
            return View(subjects_Student);
        }

        // GET: Subjects_Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjects_Student subjects_Student = db.Subjects_Student.Find(id);
            if (subjects_Student == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "Stu_FirstName", subjects_Student.StudentCode);
            ViewBag.Subject_ID = new SelectList(db.Subjects, "Subject_ID", "Subject_Name", subjects_Student.Subject_ID);
            return View(subjects_Student);
        }

        // POST: Subjects_Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Subs_Stu_No,StudentCode,Subject_ID")] Subjects_Student subjects_Student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjects_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "Stu_FirstName", subjects_Student.StudentCode);
            ViewBag.Subject_ID = new SelectList(db.Subjects, "Subject_ID", "Subject_Name", subjects_Student.Subject_ID);
            return View(subjects_Student);
        }

        // GET: Subjects_Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjects_Student subjects_Student = db.Subjects_Student.Find(id);
            if (subjects_Student == null)
            {
                return HttpNotFound();
            }
            return View(subjects_Student);
        }

        // POST: Subjects_Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subjects_Student subjects_Student = db.Subjects_Student.Find(id);
            db.Subjects_Student.Remove(subjects_Student);
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
