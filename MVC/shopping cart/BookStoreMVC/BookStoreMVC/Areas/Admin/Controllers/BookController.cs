using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BookStoreMVC.Areas.Admin.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private BookStoreDBEntities db = new BookStoreDBEntities();

        // GET: /Admin/Book/
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

        // GET: /Admin/Book/Details/5
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

        // GET: /Admin/Book/CreateEdit/103
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

        // POST: /Admin/Book/CreateEdit/103
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit([Bind(Include = "BookId,Title,Description,Price,ISBN,PublicationDate,CategoryId,PublisherId")] Book book)
        {
            if (ModelState.IsValid)
            {
                var b = db.Books.ToList();
                var b1 = b.Find(x => x.BookId == book.BookId);
                
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

        // GET: /Admin/Book/Delete/103
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
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

        // POST: /Admin/Book/Delete/103
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
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
