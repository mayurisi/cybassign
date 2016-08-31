using HelloMvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Message = "Hello ASP.NET MVC";
            //ViewData["Name"] = "Sachin";
            //TempData["City"] = "Mumbai";
            //Session["Profession"] = "Cricket Player";

            //return RedirectToAction("About");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message1 = "Your contact page.";

            return View("About");
        }
    }
}