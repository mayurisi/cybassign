using Demo.WebApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.WebApi2.Controllers
{
    public class EmployeeController : ApiController
    {
        private static List<Employee> empList = new List<Employee>()
        {
            new Employee{ EmployeeID=1, Name="Sachin", Salary=1000},
            new Employee{ EmployeeID=2, Name="Saurav", Salary=1500}
        };

        public IEnumerable<Employee> Get()
        {
            return empList;
        }

        public Employee Get(int id)
        {
            return empList[id-1];
        }

    }
}
