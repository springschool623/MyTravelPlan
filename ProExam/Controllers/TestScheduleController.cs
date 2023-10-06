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
    public class TestScheduleController : Controller
    {
        private ProExamDBEntities5 db = new ProExamDBEntities5();

        // GET: TestSchedule
        public ActionResult TestSchedule()
        {
            var lichThis = db.LichThis.Include(l => l.MonHoc);
            return View(lichThis.ToList());
        }

        // GET: TestSchedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichThi lichThi = db.LichThis.Find(id);
            if (lichThi == null)
            {
                return HttpNotFound();
            }
            return View(lichThi);
        }

        // GET: TestSchedule/Create
        public ActionResult Create()
        {
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc");
            return View();
        }

        // POST: TestSchedule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMonHoc,TenMonHoc,NgayThi,GioThi,PhongThi,SoLuongSV")] LichThi lichThi)
        {
            if (ModelState.IsValid)
            {
                db.LichThis.Add(lichThi);
                db.SaveChanges();
                return RedirectToAction("TestSchedule");
            }

            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", lichThi.MaMonHoc);
            return View(lichThi);
        }

        // GET: TestSchedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichThi lichThi = db.LichThis.Find(id);
            if (lichThi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", lichThi.MaMonHoc);
            return View(lichThi);
        }

        // POST: TestSchedule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMonHoc,TenMonHoc,NgayThi,GioThi,PhongThi,SoLuongSV")] LichThi lichThi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichThi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TestSchedule");
            }
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", lichThi.MaMonHoc);
            return View(lichThi);
        }

        // GET: TestSchedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichThi lichThi = db.LichThis.Find(id);
            if (lichThi == null)
            {
                return HttpNotFound();
            }
            return View(lichThi);
        }

        // POST: TestSchedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LichThi lichThi = db.LichThis.Find(id);
            db.LichThis.Remove(lichThi);
            db.SaveChanges();
            return RedirectToAction("TestSchedule");
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
