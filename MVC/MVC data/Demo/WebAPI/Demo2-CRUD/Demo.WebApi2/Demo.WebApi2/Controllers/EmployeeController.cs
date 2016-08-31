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
            Employee employee = empList.Find(e => e.EmployeeID == id);

            if(employee == null)
            {
                //web api translates this exception into 404 or not found error
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return employee;
        }

        public Employee Post(Employee emp)
        { 
            emp.EmployeeID = empList.Count+1;
            empList.Add(emp);

            return emp;
        }

        public void Put(int id, Employee emp)
        {
            var employee = empList.Find(e => e.EmployeeID == id);
            if(emp.EmployeeID == null)
            {
                emp.EmployeeID = employee.EmployeeID;
            }

            if(emp.Name == null)
            {
                emp.Name = employee.Name;
            }

            if(emp.Salary == null)
            {
                emp.Salary = employee.Salary;
            }

            empList.Remove(employee);
            empList.Add(emp);
        }

        public void Delete(int id)
        {
            var employee = empList.Find(e => e.EmployeeID == id);
            empList.Remove(employee);
        }
    }
}
