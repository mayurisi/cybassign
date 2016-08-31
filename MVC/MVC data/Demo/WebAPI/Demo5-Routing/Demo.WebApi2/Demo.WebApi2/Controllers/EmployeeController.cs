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
    //Overriding convention - changing action method names.
    //Replacing Get, Post, Put and Delete with Index, Details, Create, Update and Remove respectively.
    //Using HttpGet, HttpPost, HttpPut and HttpDelete top of action methods to map action methods with HTTP verbs.
     */
    public class EmployeeController : ApiController
    {
        EmployeeRepository _repository = new EmployeeRepository();

        //changing Get() to Index()
        [HttpGet]
        public IEnumerable<Employee> Index()
        {
            return _repository.GetAllEmployees();
        }

        //changing Get to Details
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

        //changing Post to Create
        [HttpPost]
        public IHttpActionResult Create(Employee emp)
        {
            emp = _repository.AddEmployee(emp);
            
            return Created(Request.RequestUri + "/" + emp.EmployeeID, emp);
            //return Created(Request.RequestUri + "" + emp.EmployeeID, emp);
        }
        

        //changing Put to Update
        [HttpPut]
        public void Update(int id, Employee emp)
        {
            emp.EmployeeID = id;

            if(!_repository.UpdateEmployee(emp))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //changing Delete to Remove
        [HttpDelete]
        public void Remove(int id)
        {
           if(!_repository.RemoveEmployee(id))
           {
               throw new HttpResponseException(HttpStatusCode.NotFound);
           }
        }
    }
}
