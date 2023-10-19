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
    public class StudentsController : Controller
    {
        private ProExamDBEntities9 db = new ProExamDBEntities9();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Class);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.Class_ID = new SelectList(db.Classes, "Class_ID", "Class_ID");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentCode,Stu_FirstName,Stu_LastName,Stu_DOB,Stu_Gender,Stu_Email,Stu_PhoneNumber,Stu_Address,Stu_Password,Class_ID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();

                // Call the CalculateStuQuantity method after saving the student
                DatabaseHelper dbHelper = new DatabaseHelper();
                dbHelper.CalculateStuQuantity();

                return RedirectToAction("Index");
            }

            ViewBag.Class_ID = new SelectList(db.Classes, "Class_ID", "Class_ID", student.Class_ID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_ID = new SelectList(db.Classes, "Class_ID", "Class_ID", student.Class_ID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentCode,Stu_FirstName,Stu_LastName,Stu_DOB,Stu_Gender,Stu_Email,Stu_PhoneNumber,Stu_Address,Stu_Password,Class_ID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Class_ID = new SelectList(db.Classes, "Class_ID", "Class_ID", student.Class_ID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
