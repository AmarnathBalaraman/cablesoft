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
    public class CustomerManagementController : Controller
    {
        CustomerManagementService _CustomerManagementService = new CustomerManagementService();
        SystemService _SystemService = new SystemService();
        public ActionResult AddCustomer()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                String userEmail = Session["Email"].ToString();
                DataSet dbInitial = _SystemService.GetInitialDetails(userEmail);
                ViewBag.ActiveMenu = "AddCustomer";
                AddCustomerModel _AddCustomer = new AddCustomerModel();


                _AddCustomer.City = dbInitial.Tables[0].AsEnumerable().Select(row => new CityModel
                {
                    CityId = Convert.ToInt32(row["CITY_CODE"]),
                    CityName = Convert.ToString(row["CITY_NAME"])
                });
                _AddCustomer.State = dbInitial.Tables[1].AsEnumerable().Select(row => new StateModel
                {
                    StateId = Convert.ToInt32(row["STATE_CODE"]),
                    StateName = Convert.ToString(row["STATE_NAME"])
                });
                _AddCustomer.Country = dbInitial.Tables[2].AsEnumerable().Select(row => new CountryModel
                {
                    CountryId = Convert.ToInt32(row["COUNTRY_CODE"]),
                    CountryName = Convert.ToString(row["COUNTRY_NAME"])
                });

                _AddCustomer.Street = dbInitial.Tables[3].AsEnumerable().Select(row => new StreetModel
                {
                    StreetId = Convert.ToInt32(row["STREET_CODE"]),
                    StreetName = Convert.ToString(row["STREET_NAME"])
                });
                _AddCustomer.Box = dbInitial.Tables[4].AsEnumerable().Select(row => new BoxModel
                {
                    BoxId = Convert.ToInt32(row["ID"]),
                    BoxName = Convert.ToString(row["BOX_NAME"])
                });
                _AddCustomer.Package = dbInitial.Tables[5].AsEnumerable().Select(row => new PackageModel
                {
                    PackageId = Convert.ToInt32(row["ID"]),
                    PackageName = Convert.ToString(row["PKG_NAME"])
                });

                return View(_AddCustomer);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }//.. End Add Customer

        [HttpPost]
        public ActionResult CreateUser(AddCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _CustomerManagementService.CreateUser(model, Session["Email"].ToString());
                    TempData["Success"] = "Success";
                    return RedirectToAction("AddCustomer");
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", ex.Message);
                    TempData["Fail"] = "Fail";
                    return View("AddCustomer", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("AddCustomer");
            }
        }//..CreateUser

        public ActionResult CustomerList()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "CustomerList";
                DataTable dt = _CustomerManagementService.CustomerList(Session["Email"].ToString());
                List<CustomerListModel> CustomerList = CommonService.ConvertToList<CustomerListModel>(dt);
                return View(CustomerList); // redirecting to all Customer List
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }//..End CustomerList

        [HttpPost]
        public ActionResult DeactivateActivateUser(CustomerListModel model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _CustomerManagementService.DeactivateActivateUser(model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("CustomerList");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("CustomerList", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("CustomerList");
            }

        }//..End DeactiveUser

        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "AddCustomer";
                String userEmail = Session["Email"].ToString();
                DataTable dt = _CustomerManagementService.ViewCustomerDetailsList();
                List<EditCustomerModel> CustomerList = CommonService.ConvertToList<EditCustomerModel>(dt);
                EditCustomerModel _EditUserModel = CustomerList.Find(uid => uid.CustomerId == id);
                DataSet dbInitial = _SystemService.GetInitialDetails(userEmail);

                _EditUserModel.City = dbInitial.Tables[0].AsEnumerable().Select(row => new CityModel
                {
                    CityId = Convert.ToInt32(row["CITY_CODE"]),
                    CityName = Convert.ToString(row["CITY_NAME"])
                });
                _EditUserModel.State = dbInitial.Tables[1].AsEnumerable().Select(row => new StateModel
                {
                    StateId = Convert.ToInt32(row["STATE_CODE"]),
                    StateName = Convert.ToString(row["STATE_NAME"])
                });
                _EditUserModel.Country = dbInitial.Tables[2].AsEnumerable().Select(row => new CountryModel
                {
                    CountryId = Convert.ToInt32(row["COUNTRY_CODE"]),
                    CountryName = Convert.ToString(row["COUNTRY_NAME"])
                });

                _EditUserModel.Street = dbInitial.Tables[3].AsEnumerable().Select(row => new StreetModel
                {
                    StreetId = Convert.ToInt32(row["STREET_CODE"]),
                    StreetName = Convert.ToString(row["STREET_NAME"])
                });

                _EditUserModel.Box = dbInitial.Tables[4].AsEnumerable().Select(row => new BoxModel
                {
                    BoxId = Convert.ToInt32(row["ID"]),
                    BoxName = Convert.ToString(row["BOX_NAME"])
                });

                _EditUserModel.Package = dbInitial.Tables[5].AsEnumerable().Select(row => new PackageModel
                {
                    PackageId = Convert.ToInt32(row["ID"]),
                    PackageName = Convert.ToString(row["PKG_NAME"])
                });

                return View(_EditUserModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }//..End of Edit Customer

        [HttpPost]
        public ActionResult UpdateCustomer(EditCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _CustomerManagementService.UpdateCustomer(Session["Email"].ToString(), model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("CustomerList");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("CustomerList", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("CustomerList");
            }
        }//..Update User

        public ActionResult ActiveCustomer()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "ActiveUsers";
                DataTable dt = _CustomerManagementService.ActiveCustomerList();
                List<CustomerListModel> CustomerList = CommonService.ConvertToList<CustomerListModel>(dt);
                return View(CustomerList); // redirecting to all Customer List                
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }//..Active User
        public ActionResult RemoveCustomer(CustomerListModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _CustomerManagementService.RemoveCustomer(model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("CustomerList");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("CustomerList", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("CustomerList");
            }
        }//..End Remove user

    }
}
