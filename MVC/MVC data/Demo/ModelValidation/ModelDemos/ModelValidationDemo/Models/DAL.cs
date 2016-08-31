using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModelValidationDemo.Models
{
    public class DAL : DbContext
    {
        public DAL()
            : base("name=DefaultConnection")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}