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
     
        public IHttpActionResult Get(int id)
        {
            Employee employee = _repository.GetEmployeeById(id);

            if(employee == null)
            {
                return NotFound();//returns 404
            }

            return Ok(employee);//returns 200 with data
        }       
      
        public IHttpActionResult Post(Employee emp)
        {
            emp = _repository.AddEmployee(emp);
            
            return Created(Request.RequestUri + "/" + emp.EmployeeID, emp);
        }    
      
        public void Put(int id, Employee emp)
        {
            emp.EmployeeID = id;

            if(!_repository.UpdateEmployee(emp))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
       
        public void Delete(int id)
        {
           if(!_repository.RemoveEmployee(id))
           {
               throw new HttpResponseException(HttpStatusCode.NotFound);
           }
        }
    }
}
