using AreaDemo.Areas.Admin.Models;
using AreaDemo.Areas.Sales.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AreaDemo.Models
{
    public class AreaDemoDB : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}