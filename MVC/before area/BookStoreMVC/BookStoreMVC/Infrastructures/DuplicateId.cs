using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace BookStoreMVC.Infrastructures
{
    public class DuplicateId : RequiredAttribute
    {
        BookStoreDBEntities db = new BookStoreDBEntities();
        public override bool IsValid(object val)
        {
            db.Books.Find(val);
            return base.IsValid(val) && ((DateTime)val) < DateTime.Now;
        }
    }
}