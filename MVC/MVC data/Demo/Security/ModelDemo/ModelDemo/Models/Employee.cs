using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelDemo.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage="Please enter name")]
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
    }
}