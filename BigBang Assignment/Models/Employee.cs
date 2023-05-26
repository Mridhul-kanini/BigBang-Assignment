using System.ComponentModel.DataAnnotations;

namespace BigBang_Assignment.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeType { get; set; } = string.Empty;
        public Hotel? Hotel { get; set; }
    }
}
