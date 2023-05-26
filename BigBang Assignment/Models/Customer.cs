using System.ComponentModel.DataAnnotations;

namespace BigBang_Assignment.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; } = string.Empty;
        public string? CustomerMail { get; set; }

        public Hotel? Hotel { get; set; }
    }
}