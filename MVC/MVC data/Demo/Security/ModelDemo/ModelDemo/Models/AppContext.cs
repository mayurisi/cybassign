using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModelDemo.Models
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("name=DefaultConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}