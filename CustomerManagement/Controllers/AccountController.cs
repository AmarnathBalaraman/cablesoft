    using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using CustomerManagement.Models;
using CustomerManagement.Services;
using System.Data;

namespace CustomerManagement.Controllers
{   
    public class AccountController : Controller
    {
        AccountService _AccountService = new AccountService();
        SystemService _SystemService = new SystemService();

        [HttpGet]
        public ActionResult Index()
        {
            if(Session["Email"] != null && Session["UserId"] != null)
            {
                ViewBag.ActiveMenu = "Dashboard";
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }//..Index

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WebLogin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _AccountService.UserAuthenticate(model);

                if (loginResult.Email != null && loginResult.UserID != 0)
                {

                    DataSet dsInitial = _SystemService.LoadDynamicMenu(loginResult.UserID.ToString(),loginResult.RoleId.ToString());
                    List<MenuModels> _menus = dsInitial.Tables[0].AsEnumerable().Select(row => new MenuModels
                    {
                        MainMenuId = Convert.ToInt32(row["MainMenuId"]),
                        MainMenuName = Convert.ToString(row["MainMenuName"]),
                        SubMenuId = Convert.ToInt32(row["SubMenuId"]),
                        SubMenuName = Convert.ToString(row["SubMenuName"]),
                        ControllerName = Convert.ToString(row["Controller"]),
                        ActionName = Convert.ToString(row["Action"]),
                        RoleId = Convert.ToInt32(row["RoleId"]),
                        RoleName = Convert.ToString(row["RoleName"])
                    }).ToList();

                    Session["UserID"] = loginResult.UserID.ToString();
                    Session["Email"] = loginResult.Email.ToString();
                    Session["Firstname"] = loginResult.Firstname.ToString();
                    Session["Position"] = loginResult.Position.ToString();
                    Session["RoleId"] = loginResult.RoleId.ToString();
                    Session["MenuMaster"] = _menus;

                    model.Password = string.Empty;

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            return RedirectToAction("Login");
        }

        //public ActionResult GetMenuList()
        //{
        //    try
        //    {
        //        DataSet dsInitial = _SystemService.LoadDynamicMenu();
        //        var result = dsInitial.Tables[0].AsEnumerable().Select(row => new Menu_List
        //        {
        //            M_ID = Convert.ToInt32(row["M_ID"]),
        //            M_P_ID = Convert.ToInt32(row["M_P_ID"]),
        //            M_NAME = Convert.ToString(row["M_NAME"]),
        //            CONTROLLER_NAME = Convert.ToString(row["CONTROLLER_NAME"]),
        //            ACTION_NAME = Convert.ToString(row["ACTION_NAME"]),
        //        });
        //        return View("Menu", result);
        //    }
        //    catch (Exception ex)
        //    {
        //        var error = ex.Message.ToString();
        //        return Content("Error");
        //    }
        //}//..End GetMenuList


    }
}