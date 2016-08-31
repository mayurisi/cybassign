using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.WebApi2.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> empList = new List<Employee>()
        {
            new Employee{ EmployeeID=1, Name="Sachin", Salary=1000},
            new Employee{ EmployeeID=2, Name="Saurav", Salary=1500}
        };

        public IEnumerable<Employee> GetAllEmployees()
        {
            return empList;
        }

        public Employee GetEmployeeById(int id)
        {
            return empList.Find(e => e.EmployeeID == id);
        }

        public Employee AddEmployee(Employee emp)
        {
            if (emp == null)
            {
                throw new NullReferenceException("Employee is null");
            }

            emp.EmployeeID = empList.Count + 1;
            empList.Add(emp);
            return emp;
        }

        public bool UpdateEmployee(Employee emp)
        {  
            //returns error with message
            if (emp == null)
            {
                throw new ArgumentNullException("Employee is null");
            }

            var employee = empList.Find(e => e.EmployeeID == emp.EmployeeID);

            if(employee == null)
            {
                return false;
            }

            empList.Remove(employee);
            empList.Add(emp);
            return true;
        }

        public bool RemoveEmployee(int id)
        {
            var employee = empList.Find(e => e.EmployeeID == id);

            //returns error with message
            if (employee == null)
            {
                return false;
            }

            empList.Remove(employee);
            return true;
        }
    }
}