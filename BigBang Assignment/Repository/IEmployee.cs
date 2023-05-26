using BigBang_Assignment.Models;
using System.Collections.Generic;

namespace BigBang_Assignment.Repository
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int EmployeeId);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(int EmployeeId, Employee employee);
        Employee DeleteEmployee(int EmployeeId);
    }
}
