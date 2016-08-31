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
     *Using Attribute Routing
     *disabling mvc style route and enabling web api route
     */
    public class Employee4Controller : ApiController
    {
        //URL calls this method is : http://localhost:54450/api/employee4/
        public string GetEmployeeByDepartments()
        {
            return "Returns all employees working in a particular department";
        }

        //URL calls this method is defined using following attribute
        //The departmentId in route matches with parameter name, that is why web api binds value 1 to departmentId parameter.
        //URL : http://localhost:54450/department/1/employee
        [Route("department/{departmentId}/employee")]
        public string GetEmployeeByDepartments(int departmentId)
        {
            return "Returns all employees working in department id : " + departmentId;
        }

        //Using Route constraints - puts restriction on how urls are matched with routing template
        //Constraint {id:int} checks url, if integer is passed then GetEmployeeById is called and 
        //if string is passed the GetEmployeeByName is called.
        //URL to call following action : http://localhost:54450/employee/1
        [Route("employee/{id:int}")]
        public string GetEmployeeById(int id)
        {
            return "GetEmployeeById returns employee details of employee id : " + id;
        }      

        //URL to call following action : http://localhost:54450/employee/Sachin
        [Route("employee/{name}")]
        public string GetEmployeeByName(string name)
        {
            return "Returns employee details of employee name : " + name;
        }       
    }
}
