using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleTest.Models;
using SampleTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer customerservice;
        public CustomerController(ICustomer customer)
        {
            customerservice = customer;
        }

        [HttpGet]
        [Route("api/customer/getcustomers")]
        public IEnumerable<Customer> GetCustomers()
        {
            return customerservice.GetCustomers();
        }

        [HttpGet]
        [Route("api/customer/login/{id},{password}")]
        public IActionResult Logintocustomer(string id, string password)
        {
            var result = customerservice.Logintocustomer(id, password);
            if (result != null)
            {
                return Ok("Login Successfully!!");
            } 
            return NotFound($"User Not Found: {id} , Please check UserID & Password");
        }
        [HttpPost]
        [Route("api/customer/add")]
        public Customer AddCustomer(Customer customer)
        {
            return customerservice.AddCustomer(customer);

        }
        [HttpDelete]
        [Route("api/Customer/DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            customerservice.DeleteCustomer(id);
            return Ok("You have Deleted the Record Successfully!");
        }

        [HttpPost]
        [Route("api/Customer/UpdateCustomer")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            customerservice.UpdateCustomer(customer);
            return Ok("Record updated Successfully!");

        }
        [HttpPost]
        [Route("api/EditProfile/{customerid},{customername},{email},{dob}")]
        public IActionResult EditProfile(string customerid, string customername, string email, string dob)
        {
            customerservice.EditProfile(customerid, customername, email, dob);
            return Ok("Profile Edited Successfully!");
        }
    }
}
