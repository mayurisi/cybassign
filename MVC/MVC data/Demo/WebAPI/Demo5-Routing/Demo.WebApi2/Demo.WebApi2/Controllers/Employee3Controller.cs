using Demo.WebApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.WebApi2.Controllers
{
    /*
     *Using MVC style routing.
     *Using ActionName attribute top of action methods to override name of action methods.
     *It allows to call different action methods using same name.
     *Using NonAction attribute an action method call can be prevented.
     */
    public class Employee3Controller : ApiController
    {
        EmployeeRepository _repository = new EmployeeRepository();

        //changing Get() to Index()
        //http://localhost:54450/api/employee3/Index
        [HttpGet]
        [ActionName("Index")]
        public IEnumerable<Employee> ShowAllEmployee()
        {
            return _repository.GetAllEmployees();
        }

        //changing Get to Details
        //http://localhost:54450/api/employee3/Details/1
        [HttpGet]
        [ActionName("Index")]
        public IHttpActionResult ShowEmployeeById(int id)
        {
            Employee employee = _repository.GetEmployeeById(id);

            if(employee == null)
            {
                return NotFound();//returns 404
            }

            return Ok(employee);//returns 200 with data
        }
       
        //This method can not be invoked as action method.
        [HttpGet]
        [NonAction]
        public string HelperMethod()
        {
            return "Helper Method is called";
        }
    }
}
