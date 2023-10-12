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
        private ProExamDBEntities8 db = new ProExamDBEntities8();

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
    }
}