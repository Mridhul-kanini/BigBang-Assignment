using BigBang_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BigBang_Assignment.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly HotelContext _context;

        public CustomerRepository(HotelContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public Customer AddCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public Customer UpdateCustomer(int customerId, Customer customer)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);

            if (existingCustomer == null)
                return null;

            existingCustomer.CustomerName = customer.CustomerName;
            existingCustomer.CustomerMail = customer.CustomerMail;

            _context.SaveChanges();

            return existingCustomer;
        }

        public Customer DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);

            if (customer == null)
                return null;

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return customer;
        }
    }
}
