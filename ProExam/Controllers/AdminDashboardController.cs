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
    public class AdminDashboardController : Controller
    {
        private ProExamDBEntities8 db = new ProExamDBEntities8();

        // GET: AdminDashboard
        public ActionResult ADHomePage()
        {
            return View();
        }


        
    }
}