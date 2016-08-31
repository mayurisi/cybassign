﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /HelloWorld/
        //public string Index()
        //{
        //    return "This is <b>default</b> action";
        //}

        //// GET: /HelloWorld/Welcome
        public ActionResult Welcome(string name, int ID = 1)
        {
            ViewBag.Message = "Name :" + name;
            ViewBag.NumTimes = ID;
            
            return View();
        }
	}
}