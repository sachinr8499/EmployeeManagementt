using EmployeeManagementMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            Session["empty-fields"] = "none";
            Session["wrong"] = "none";
            IEnumerable<MvcEmployee> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MvcEmployee>>().Result;
            return View(empList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new MvcEmployee());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee/"+id.ToString()).Result;
                var emp = response.Content.ReadAsAsync<MvcEmployee>().Result;
                emp.Name = emp.Name.Trim();
                emp.Skills = emp.Skills.Trim();
                emp.Department = emp.Department.Trim();
                emp.Status = emp.Status.Trim();
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcEmployee emp)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("AddOrEdit");
            }
            if(emp.ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMessage"] = "Employee Data Saved Successfully!";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employee/" + emp.ID.ToString(), emp).Result;
                TempData["SuccessMessage"] = "Employee Data Updated Successfully!";
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employee/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Employee Data Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}