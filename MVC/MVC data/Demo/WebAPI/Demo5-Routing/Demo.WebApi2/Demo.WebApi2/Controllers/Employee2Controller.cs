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
     *Create a new route to support action method.
     *Put HttpGet top of Index and Details.
     *Pass action method name along with the controller now.
     */
    public class Employee2Controller : ApiController
    {
        EmployeeRepository _repository = new EmployeeRepository();

        //changing Get() to Index()
        //http://localhost:54450/employee2/Index
        [HttpGet]
        public IEnumerable<Employee> Index()
        {
            return _repository.GetAllEmployees();
        }

        //changing Get to Details
        //http://localhost:54450/employee2/Details/1
        [HttpGet]
        public IHttpActionResult Details(int id)
        {
            Employee employee = _repository.GetEmployeeById(id);

            if(employee == null)
            {
                return NotFound();//returns 404
            }

            return Ok(employee);//returns 200 with data
        }
       
    }
}
