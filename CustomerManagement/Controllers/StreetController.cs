using CustomerManagement.Models;
using CustomerManagement.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagement.Controllers
{
    public class StreetController : Controller
    {
               StreetService _StreetService = new StreetService();
        // GET: /Street/
       //
       // GET: /Street/Create
       public ActionResult AddStreet()
       {
           return View();
       }
        [HttpPost]
        public ActionResult AddStreet(StreetModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _StreetService.CreateStreet(model,Session["Email"].ToString());
                    TempData["Success"] = "Success";
                    return RedirectToAction("StreetList");
                 }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", ex.Message);
                    TempData["Fail"] = "Fail";
                    return View("AddStreet", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("AddStreet");
            }
        }//..CreateUser
        public ActionResult StreetList()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "StreetList";
                DataTable dt = _StreetService.StreetList(Session["Email"].ToString());

                List<StreetModel> StreetList = CommonService.ConvertToList<StreetModel>(dt);
            //   return View(StreetList); // redirecting to all Street List
                return Json(new { data = StreetList }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }//..End CustomerList
        public ActionResult UpdateStreet(EditStreetModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                
                   _StreetService.UpdateStreet(model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("StreetList");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("StreetList", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("StreetList");
            }
        }//..Update User

        public ActionResult EditStreet(int id)
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "AddStreet";
                String userEmail = Session["Email"].ToString();
                DataTable dt = _StreetService.ViewStreetList();
                List<EditStreetModel> StreetList = CommonService.ConvertToList<EditStreetModel>(dt);
                EditStreetModel _EditStreetModel = StreetList.Find(uid => uid.StreetId == id);
                
                return View(_EditStreetModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }//..End of Edit Customer
        public ActionResult Index()
        {
            return View();
        }

    }
      
        
    }
