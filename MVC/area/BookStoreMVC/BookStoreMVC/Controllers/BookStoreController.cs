using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using System;
using System.Collections.Generic;

namespace BookStoreMVC.Controllers
{
    [Authorize]
    public class BookStoreController : Controller
    {
        BookStoreDBEntities db = new BookStoreDBEntities();

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
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: /BookStore/CreateEdit/103
        public ActionResult CreateEdit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /BookStore/CreateEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit([Bind(Include = "BookId,Title,Description,Price,ISBN,PublicationDate,CategoryId,PublisherId")] Book book)
        {
            if (ModelState.IsValid)
            {
                var b = db.Books.ToList();
                var b1 = b.Find(x => x.BookId == book.BookId);
                //book = db.Books.Find(id);
                if (b1 == null)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    db.Entry(b1).CurrentValues.SetValues(book);
                    //db.Entry(book).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                
            }
            return View(book);
        }       

        //// GET: /BookStore/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}        

        //// POST: /BookStore/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BookId,Title,Description,Price,ISBN,PublicationDate,CategoryId,PublisherId")] Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Books.Add(book);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(book);
        //}

        //// GET: /BookStore/Edit/103
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Book book = db.Books.Find(id);
        //    if (book == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(book);
        //}

        //// POST: /BookStore/Edit/103
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BookId,Title,Description,Price,ISBN,PublicationDate,CategoryId,PublisherId")] Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(book).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(book);
        //}

        // GET: /BookStore/Delete/104 
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Request.IsAuthenticated)
            {
                if (User.IsInRole("admin"))
                {
                    Book book = db.Books.Find(id);
                    if (book == null)
                    {
                        return HttpNotFound();
                    }
                    return View(book);
                }                
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View("Error");            
        }

        // POST: /BookStore/Delete/104       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]        
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Dispose to release resources
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