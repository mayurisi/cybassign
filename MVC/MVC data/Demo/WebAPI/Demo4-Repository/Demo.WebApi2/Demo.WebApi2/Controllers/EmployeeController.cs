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
        EmployeeRepository _repository = new EmployeeRepository();

        public IEnumerable<Employee> Get()
        {
            return _repository.GetAllEmployees();
        }

        //using IHttpActionResult interface
        public IHttpActionResult Get(int id)
        {
            Employee employee = _repository.GetEmployeeById(id);

            if(employee == null)
            {
                return NotFound();//returns 404
            }

            return Ok(employee);//returns 200 with data
        }

        //IHttpActionResult hides low level details of constructing the response
        public IHttpActionResult Post(Employee emp)
        {
            emp = _repository.AddEmployee(emp);
            
            return Created(Request.RequestUri + "/" + emp.EmployeeID, emp);
        }
        

        //Web Api translates void return type to 204(no content) automatically
        public void Put(int id, Employee emp)
        {
            emp.EmployeeID = id;

            if(!_repository.UpdateEmployee(emp))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //Web Api translates void return type to 204(no content) automatically
        public void Delete(int id)
        {
           if(!_repository.RemoveEmployee(id))
           {
               throw new HttpResponseException(HttpStatusCode.NotFound);
           }
        }
    }
}
