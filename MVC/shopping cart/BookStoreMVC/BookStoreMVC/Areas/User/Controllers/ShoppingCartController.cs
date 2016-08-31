using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreMVC.Areas.User.Controllers
{
    public class ShoppingCartController : Controller
    {
        BookStoreDBEntities db = new BookStoreDBEntities();
        //
        // GET: /User/ShoppingCart/
        public ActionResult Index()
        {
            return View();
        }
	}
}