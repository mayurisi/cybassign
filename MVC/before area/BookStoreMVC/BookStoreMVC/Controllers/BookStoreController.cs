using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using System;

namespace BookStoreMVC.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class BookStoreController : Controller
    {
        BookStoreDBEntities db = new BookStoreDBEntities();

       // [AllowAnonymous]
        public ActionResult index(string searchStr)
        {
            var bookmodel = db.Books.ToList();

            //var book1 = db.GetBookByCategory11(searchStr);


            var book = from b in db.Books
                         select b;

            if (!String.IsNullOrEmpty(searchStr))
            {
                book = book.Where(s => s.Title.Contains(searchStr));
            }

            return View(bookmodel);
        }

        // GET: /BookStore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BookStore/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Title,Description,Price,ISBN,PublicationDate,CategoryId,PublisherId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //[AllowAnonymous]
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

        // GET: /BookStore/Edit/103
        public ActionResult Edit(int? id)
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

        // POST: /BookStore/Edit/103
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Title,Description,Price,ISBN,PublicationDate,CategoryId,PublisherId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: /BookStore/Delete/104
        //[AllowAnonymous]
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

        // POST: /BookStore/Delete/104
        //[AllowAnonymous]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


	}
}