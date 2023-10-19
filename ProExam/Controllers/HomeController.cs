using ProExam.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProExam.Controllers
{
    public class HomeController : Controller
    {
        private ProExamDBEntities9 db = new ProExamDBEntities9();

        // GET: Home
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult US_Subject()
        {
            // Get the user code from the session variable
            string userCode = Session["UserCode"] as string;

            // If the user code is null, redirect to the login page
            if (userCode == null)
            {
                return RedirectToAction("Home", "Home");
            }

            // Use the user code to retrieve the user's information from the database
            var user = db.Students.FirstOrDefault(u => u.StudentCode == userCode);


            // Return the view
            var subjects_Student = db.Subjects_Student.Include(s => s.Student).Include(s => s.Subject);
            return View(subjects_Student.ToList());
        }

        // Action to render partial view directly
        public ActionResult RenderPartialView()
        {
            return PartialView("LoginSection");
        }

        [HttpPost]
        public ActionResult Login(LoginInfo loginInfo)
        {
            // Check if the loginInfo is for a Student
            var isStudent = db.Students.Any(u => u.StudentCode == loginInfo.UserCode && u.Stu_Password == loginInfo.Password);

            // Check if the loginInfo is for a Teacher
            var isTeacher = db.Teachers.Any(u => u.TeacherCode == loginInfo.UserCode && u.Tea_Password == loginInfo.Password);


            if (isStudent || isTeacher)
            {
                // Set the "UserCode" session variable to the user code
                Session["UserCode"] = loginInfo.UserCode;

                // Redirect to the Home action with the usercode route parameter
                return RedirectToAction("Home", new { usercode = loginInfo.UserCode });
            }
            else if (loginInfo.UserCode == "admin" && loginInfo.Password == "admin12345")
            {
                // Set the "UserCode" session variable to "admin" for admin
                Session["UserCode"] = "admin";


                // Redirect to the ADHomePage action with the usercode route parameter
                return RedirectToAction("ADHomePage", new { usercode = "admin" });
            }
            else
            {
                // Invalid login, return to the login page with an error message
                ModelState.AddModelError("", "Invalid student ID or password");

                // Return the loginInfo object to repopulate the form with user-entered values
                return View("Home", loginInfo);
            }
        }


        public ActionResult Logout()
        {
            // Clear session
            Session.Clear();

            // Redirect to the login page
            return RedirectToAction("Home", "Home");
        }
    }
}