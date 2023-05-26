using BigBang_Assignment.Models;
using System.Collections.Generic;

namespace BigBang_Assignment.Repository
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(int customerId, Customer customer);
        Customer DeleteCustomer(int customerId);
    }
}
