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

        /*
        //Example-1
        public Employee Get(int id)
        {
            Employee employee = empList.Find(e => e.EmployeeID == id);


            if (employee == null)
            {
                //web api translates this exception into 404 or not found error
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return employee;
        }*/
        

        /*
        //Example-2
        //return type changed to HttpResponseMessage from Employee
        public HttpResponseMessage Get(int id)
        {
            Employee employee = empList.Find(e => e.EmployeeID == id);

            //returns error with message
            if(employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee not found");
            }    

            //otherwise returns employee
            return Request.CreateResponse<Employee>(HttpStatusCode.OK, employee);           
        }*/

        //Example-3
        //using IHttpActionResult interface
        
        public IHttpActionResult Get(int id)
        {
            Employee employee = empList.Find(e => e.EmployeeID == id);

            if(employee == null)
            {
                return NotFound();//returns 404
            }

            return Ok(employee);//returns 200 with data
        }
        
        //Example-1
        
        //return type changed to HttpResponseMessage from Employee
        public HttpResponseMessage Post(Employee emp)
        {
            if(emp == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Employee is null", new NullReferenceException());
            }

            emp.EmployeeID = empList.Count+1;
            empList.Add(emp);

            var msg = Request.CreateResponse(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + "/" + (emp.EmployeeID).ToString());
            return msg;
        }
        

        //Example-2
        /*
        //return type changed to IHttpActionResult from HttpResponseMessage
        //IHttpActionResult hides low level details of constructing the response
        public IHttpActionResult Post(Employee emp)
        {
            if(emp == null)
            {
                return InternalServerError(new NullReferenceException("Employee is null"));
            }

            emp.EmployeeID = empList.Count+1;
            empList.Add(emp);

            //var msg = Request.CreateResponse(HttpStatusCode.Created);
            //msg.Headers.Location = new Uri(Request.RequestUri + "/" + (emp.EmployeeID).ToString());
            //return msg;
            return Created(Request.RequestUri + "/" + emp.EmployeeID, emp);
        }
        */

        //Web Api translates void return type to 204(no content) automatically
        public void Put(int id, Employee emp)
        {
            var employee = empList.Find(e => e.EmployeeID == id);

            //returns error with message
            if (employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }    

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

        //Web Api translates void return type to 204(no content) automatically
        public void Delete(int id)
        {
            var employee = empList.Find(e => e.EmployeeID == id);

            //returns error with message
            if (employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }  

            empList.Remove(employee);
        }
    }
}
