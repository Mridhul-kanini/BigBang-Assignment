using BigBang_Assignment.Models;
using BigBang_Assignment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BigBang_Assignment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerRepository;

        public CustomerController(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _customerRepository.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving customers: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                var customer = _customerRepository.GetCustomerById(id);
                if (customer == null)
                    return NotFound();

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the customer: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            try
            {
                var newCustomer = _customerRepository.AddCustomer(customer);
                return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.CustomerId }, newCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the customer: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            try
            {
                var updatedCustomer = _customerRepository.UpdateCustomer(id, customer);
                if (updatedCustomer == null)
                    return NotFound();

                return Ok(updatedCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the customer: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var deletedCustomer = _customerRepository.DeleteCustomer(id);
                if (deletedCustomer == null)
                    return NotFound();

                return Ok(deletedCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the customer: {ex.Message}");
            }
        }
    }
}
