using BigBang_Assignment.Models;
using System.Collections.Generic;

namespace BigBang_Assignment.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly HotelContext _context;

        public EmployeeRepository(HotelContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        public Employee GetEmployeeById(int EmployeeId)
        {
            return _context.Employees.Find(EmployeeId);
        }

        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(int EmployeeId, Employee employee)
        {
            var existingEmployee = _context.Employees.Find(EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.EmployeeName = employee.EmployeeName;
                existingEmployee.EmployeeType = employee.EmployeeType;
                existingEmployee.Hotel = employee.Hotel;
                _context.SaveChanges();
            }
            return existingEmployee;
        }

        public Employee DeleteEmployee(int EmployeeId)
        {
            var existingEmployee = _context.Employees.Find(EmployeeId);
            if (existingEmployee != null)
            {
                _context.Employees.Remove(existingEmployee);
                _context.SaveChanges();
            }
            return existingEmployee;
        }
    }
}
