using ProExam.Models;
using System.Linq;
using System.Web.Mvc;

namespace ProExam.Controllers
{
    public class LoginController : Controller
    {
        private ProExamDBEntities8 db = new ProExamDBEntities8();

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

                return RedirectToAction("Home", "Home");
            }
            else if (loginInfo.UserCode == "admin" && loginInfo.Password == "admin12345")
            {
                // Set the "UserCode" session variable to "admin" for admin
                Session["UserCode"] = "admin";

                return RedirectToAction("ADHomePage", "AdminDashboard");
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
