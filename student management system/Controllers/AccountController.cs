using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using student_management_system.Models;

namespace student_management_system.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (model.CheckLogin(model))
            {
                Session["UserName"] = model.Username;

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid Username or Password";

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}

