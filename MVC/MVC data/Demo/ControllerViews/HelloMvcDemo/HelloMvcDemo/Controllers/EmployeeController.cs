using HelloMvcDemo.Models;
using System;
using System.Web.Mvc;
using HelloMvcDemo.ViewModels;

namespace HelloMvcDemo.Controllers
{
    //[HandleError(View = "Error2")]
    public class EmployeeController : Controller
    {
        //public string Index(int id=1)
        //{
        //    return "Hello to Employee - Id = " + id;
        //}

        //public string Search()
        //{
        //    return "Searching employee by .....";
        //}

        
        public ActionResult Index(int? id)
        {
            //throw new DivideByZeroException();
            Session["Username"] = "admin";

            var employeeModel = new EmployeeViewModel()
            {
                EmployeeId = 1,
                Name = "Sachin",
                City = "Mumbai",
                Username = Session["Username"].ToString()
            };

            return View(employeeModel);
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //[ActionName("MyIndex")]
        //public ActionResult Index()
        //{
        //    var employeeModel = new Employee()
        //    {
        //        EmployeeId = 1,
        //        Name = "Sachin",
        //        City = "Mumbai"
        //    };

        //    return View(employeeModel);
        //}

        //public FileResult Index2()
        //{
        //    return File(Server.MapPath("~/controllers/EmployeeController.cs"), "text");
        //}

        //public JsonResult Index2()
        //{
        //    return Json(new {EmployeeId = 1, name = "Sachin"}, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult Index2()
        //{
        //    return RedirectToAction("Index");
        //}
    }
}