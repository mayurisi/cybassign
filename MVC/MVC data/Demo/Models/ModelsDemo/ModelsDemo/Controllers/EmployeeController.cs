using ModelsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelsDemo.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> db = new List<Employee>()
        {
            //new Employee{ EmployeeId=1, Name="Sachin", City="Mumbai"},
            //new Employee{ EmployeeId=2, Name="Saurav", City="Kolkata"}
        };

        //
        // GET: /Employee/
        public ActionResult Index()
        {
            var employeeModel = from emp in db
                                select emp;

            return View(employeeModel);
        }

        public ActionResult ShowDetails(int? id)
        {
            var employee = db.Find(emp => emp.EmployeeId == id);
            if(employee != null)
            {
                return View(employee);
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddEmployee()
        {
            return View();
        }

         [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddEmployee(Employee emp)
        {
            if (emp != null)
            {
                //explicitly validating data
                if(string.IsNullOrEmpty(emp.Name))
                {
                    //adding model error to model state makes isvalid property false
                    ModelState.AddModelError("Name", "Please enter name");
                }

                //very important to check validation errors before saving to data to db
                if(ModelState.IsValid)
                {
                    db.Add(emp);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
         public ActionResult EditEmployee(int id)
         {
             var employee = db.Find(emp => emp.EmployeeId == id);
             if (employee != null)
             {
                 return View(employee);
             }
             return HttpNotFound();
         }

        [HttpPost]
         public ActionResult EditEmployee(Employee emp)
         {
            var employee = db.Find(e => e.EmployeeId == emp.EmployeeId);
             if (emp != null)
             {
                 db.Remove(employee);
                 db.Add(emp);
                 return RedirectToAction("Index");
             }
             return View();
         }

        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = db.Find(emp => emp.EmployeeId == id);
            if (employee != null)
            {
                return View(employee);
            }
            return HttpNotFound();            
        }

        [ActionName("DeleteEmployee")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var employee = db.Find(e => e.EmployeeId == id);
            if (employee != null)
            {
                db.Remove(employee);               
                return RedirectToAction("Index");
            }
            return View();
        }
	}
}