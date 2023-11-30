using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementMVC.Models;

namespace EmployeeManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["wrong"] != "block")
            {
                Session["wrong"] = "none";
            }
            ViewBag.login = "none";
            return View();
        }

        [HttpPost]
        public ActionResult Login(MvcAdmin admin)
        {
            IEnumerable<MvcAdmin> adminList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Admin").Result;
            TempData["SuccessMessage"] = "Employee Data Updated Successfully!";
            adminList = response.Content.ReadAsAsync<IEnumerable<MvcAdmin>>().Result;
            var doesExist = false;

            foreach (MvcAdmin adm in adminList)
            {
                if (admin.Username == adm.Username)
                {
                    if (admin.Password == adm.Password)
                    {
                        doesExist = true;
                        break;
                    }
                }
            }

            if (doesExist)
            {
                ViewBag.login = "block";
                return RedirectToAction("Index", "Employee", new { area = "Admin" });
            }
            else
            {
                Session["wrong"] = "block";
                return RedirectToAction("Index");
            }
        }
    }
}

