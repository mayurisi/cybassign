using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreMVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStoreMVC.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }
       
        // Get All Roles
        
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        // Create  a New role
        public ActionResult Create()
        {
            //var Role = new IdentityRole();
            //return View(Role);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                context.Roles.Add(role);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }
               
        //[HttpPost]
        //public ActionResult Create(IdentityRole Role)
        //{
        //    context.Roles.Add(Role);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
     
	}
}



 
