using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApi2.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee emp);
        bool UpdateEmployee(Employee emp);
        bool RemoveEmployee(int id);
    }
}
