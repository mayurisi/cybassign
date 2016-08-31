using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelsDemo.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public decimal Salary { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOJ { get; set; }
    }
}