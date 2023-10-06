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
        private ProExamDBEntities5 db = new ProExamDBEntities5();

        // GET: Home
        public ActionResult Home()
        {
            return View();
        }

        // Action to render partial view directly
        public ActionResult RenderPartialView()
        {
            return PartialView("LoginSection");
        }

        [HttpPost]
        public ActionResult Login(LoginInfo loginInfo)
        {
            // Validate loginInfo and perform authentication
            // For example, you can check against your database
            var isValidUser = db.LoginInfoes.Any(u => u.UserCode == loginInfo.UserCode && u.Password == loginInfo.Password);

            if (isValidUser)
            {
                // Successful login, set user information in session
                Session["UserCode"] = "hi";

                if (loginInfo.UserCode == "admin")
                {
                    return RedirectToAction("ADHomePage", "AdminDashboard");
                } else 
                {
                    Session["UserCode"] = "hi";

                    return RedirectToAction("Home");
                }
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
            return RedirectToAction("Home");
        }

    }
}