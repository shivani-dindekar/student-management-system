using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace student_management_system.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Login Check
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Account");
            }


        return View();
        }

        public ActionResult About()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}
