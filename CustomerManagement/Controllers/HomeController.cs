using CustomerManagement.Models;
using CustomerManagement.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CustomerManagement.Controllers
{
    public class HomeController : Controller
    {
        HomeService _HomeService = new HomeService();
        public ActionResult Index()
        {
            if (Session["Email"] != null && Session["UserId"] != null)
            {
                ViewBag.ActiveMenu = "Dashboard";
                return View(_HomeService.DashboardStats(Session["Email"].ToString()));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Login", "Account");
        }
    }
}