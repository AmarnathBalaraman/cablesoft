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
    public class UserManagementController : Controller
    {
        UsersManagementService _UsersManagementService = new UsersManagementService();
        SystemTools _SystemTools = new SystemTools();

        public ActionResult AddUser()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "AddUser";
                AddUserModel _AddUserModel = new AddUserModel();
                DataSet dbInitial = _UsersManagementService.LoadDetail(Session["Email"].ToString());
                _AddUserModel.Position = dbInitial.Tables[0].AsEnumerable().Select(row => new PositionModel
                {
                    PositionId = Convert.ToInt32(row["GR_CODE"]),
                    PositionName = Convert.ToString(row["DESCRIPTION"])
                });
                _AddUserModel.Area = dbInitial.Tables[1].AsEnumerable().Select(row => new AreaModel
                {
                    AreaCode = Convert.ToInt32(row["AREA_CODE"]),
                    AreaName = Convert.ToString(row["AREA_NAME"])
                });
                _AddUserModel.sex = _SystemTools.GetGender();
                return View(_AddUserModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }//..End User

        public ActionResult AddCollectionUser()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "AddUser";
                AddCollectionUserModel _AddUserModel = new AddCollectionUserModel();
                DataSet dbInitial = _UsersManagementService.LoadDetail(Session["Email"].ToString(), "OPERATOR");
                _AddUserModel.Position = dbInitial.Tables[0].AsEnumerable().Select(row => new PositionModel
                {
                    PositionId = Convert.ToInt32(row["GR_CODE"]),
                    PositionName = Convert.ToString(row["DESCRIPTION"])
                });
                _AddUserModel.Street = dbInitial.Tables[1].AsEnumerable().Select(row => new StreetModel
                {
                    StreetId = Convert.ToInt32(row["STREET_CODE"]),
                    StreetName = Convert.ToString(row["STREET_NAME"])
                });
                _AddUserModel.sex = _SystemTools.GetGender();
                return View(_AddUserModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }//..End User

        [HttpPost]
        public JsonResult IsUserExists(string Email)
        {
            return Json(CheckUserEmail(Email));
        }

        public bool CheckUserEmail(string Email)
        {
            var result = _UsersManagementService.UsersList(Session["Email"].ToString()).Find(Rdr => Rdr.Email == Email);

            bool status;

            if (result != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }

            return status;
        }

        public ActionResult UsersList()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "UsersList";
                return View(_UsersManagementService.UsersList(Session["Email"].ToString()).ToList()); // redirecting to all Users List
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }//..End UserList

        [HttpPost]
        public ActionResult RemoveUser(UsersListModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _UsersManagementService.RemoveUser(model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("UsersList");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("UsersList", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("UsersList");
            }
        }//..End Remove user

        [HttpPost]
        public ActionResult DeactivateActivateUser(UsersListModel model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _UsersManagementService.DeactivateActivateUser(model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("UsersList");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("UsersList", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("UsersList");
            }

        }

        [HttpPost]
        public ActionResult CreateUser(AddUserModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _UsersManagementService.CreateUser(model);
                    TempData["Success"] = "Sucess";
                    return RedirectToAction("AddUser");
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", ex.Message);
                    TempData["Fail"] = "Fail";
                    return View("AddUser", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("AddUser");
            }
        }//..Create User

        //Add Collection Person
        [HttpPost]
        public ActionResult CreateCollectionUser(AddCollectionUserModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _UsersManagementService.CreateCollectionUser(Session["Email"].ToString(), model);
                    TempData["Success"] = "Sucess";
                    return RedirectToAction("AddUser");
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", ex.Message);
                    TempData["Fail"] = "Fail";
                    return View("AddUser", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("AddUser");
            }
        }//..Create User

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "AddUser";
                EditUserModel _EditUserModel = _UsersManagementService.ViewUserDetailsList(Session["Email"].ToString()).Find(uid => uid.UserID == id);
                DataSet dbInitial = _UsersManagementService.LoadDetail(Session["Email"].ToString(), "OPERATOR");
                _EditUserModel.Position = dbInitial.Tables[0].AsEnumerable().Select(row => new PositionModel
                {
                    PositionId = Convert.ToInt32(row["GR_CODE"]),
                    PositionName = Convert.ToString(row["DESCRIPTION"])
                });
                _EditUserModel.sex = _SystemTools.GetGender();
                return View(_EditUserModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }//..EditUser

        [HttpPost]
        public ActionResult UpdateUser(EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {                    
                    _UsersManagementService.UpdateUser(model,Session["Email"].ToString());
                    TempData["Success"] = "Success";
                    return RedirectToAction("UsersList");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("UsersList", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("UsersList");
            }
        }//..Update User

        public ActionResult ActiveUsers()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "ActiveUsers";
                return View(_UsersManagementService.ActiveUsersList(Session["Email"].ToString()).ToList()); // redirecting to all Activve Users List
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }//..Active User

        public ActionResult InActiveUsers()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "InActiveUsers";
                return View(_UsersManagementService.InActiveUsersList().ToList()); // redirecting to all InActive Users List
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }//.. InActiveUsers

        public ActionResult ArchivedUsers()
        {
            return View(_UsersManagementService.ArchivedUsersList().ToList()); // redirecting to all Removed Users List
        }
    }
}