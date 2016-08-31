using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BookStoreMVC.Areas.User.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        BookStoreDBEntities db = new BookStoreDBEntities();
       
        // GET: /User/User/       

        [AllowAnonymous]
        public ActionResult index(string bookCat, string searchStr)
        {
            var bookmodel = db.Books.ToList();
            //return View(bookmodel);

            var CatLst = new List<string>();

            var CatQry = from d in db.Categories
                         orderby d.categoryId
                         select d.categoryName;

            CatLst.AddRange(CatQry.Distinct());
            ViewBag.bookCat = new SelectList(CatLst);

            var book = from b in db.Books
                       select b;

            if (!String.IsNullOrEmpty(searchStr))
            {
                book = book.Where(s => s.Title.Contains(searchStr));
            }

            if (!string.IsNullOrEmpty(bookCat))
            {
                book = book.Where(x => x.Category.categoryName == bookCat);
            }

            return View(book);
        }

        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}