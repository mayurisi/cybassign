using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStoreMVC.Infrastructures
{
    public class NotFutureDate : RequiredAttribute
    {
        public override bool IsValid(object val)
        {
            return base.IsValid(val) && ((DateTime)val) < DateTime.Now;
        }
    }
}