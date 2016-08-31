using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.WebApi2.Models
{
    public class Employee
    {
        public int? EmployeeID { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }
    }
}