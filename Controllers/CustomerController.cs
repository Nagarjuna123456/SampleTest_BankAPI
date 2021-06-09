using Microsoft.AspNetCore.Cors;
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

        //[HttpGet]
        //[Route("api/customer/getcustomers")]
        //public IEnumerable<Customer> GetCustomers()
        //{
        //    return customerservice.GetCustomers();
        //}
        [HttpGet]
        [Route("api/customer/getcustomers")]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return Ok(customerservice.GetCustomers());
        }

        [HttpPost]
        [EnableCors("CorsApi")]
        [Route("api/customer/login/{email},{password}")]
        public IActionResult Logintocustomer(string email, string password)
        {
            var result = customerservice.Logintocustomer(email, password);
            if (result != null)
            {
                return Ok("Login Successfully!!");
            } 
            return NotFound($"User Not Found: {email} , Please check UserID & Password");
        }

        [HttpPost]
        [EnableCors("CorsApi")]
        [Route("api/Login")]
        public Response customerLogin([FromBody]Customer login)
        {
            var result = customerservice.Logintocustomer(login.Email, login.Password);
            if(result == null)
            {
                return new Response { Status = "Invalid!", Message = "Please try again!" };
            }
            else
            {
                return new Response { Status = "Success!", Message = "Login Successfully!" };
            }

        }


        [HttpPost]
        [EnableCors("CorsApi")]
        [Route("api/customer/add")]
        public Customer AddCustomer(Customer customer)
        {
            return customerservice.AddCustomer(customer);

        }

        [HttpPost]
        [EnableCors("CorsApi")]
        [Route("api/customer/register")]
        public IActionResult Register([FromBody] Customer customer)
        {
            //return customerservice.AddCustomer(customer);
            if(customer == null)
            {
                return Ok(new Response { Status = "Invalid!", Message = "Record not inserted!" });
            }
            else
            {
                var result = customerservice.AddCustomer(customer);
                if(result != null)
                {
                    return Ok(new Response { Status = "Success", Message = "Record inserted!" });
                }
                else
                {
                    return Ok(new Response { Status = "Invalid!", Message = "Record not inserted!" });

                }
                
            }

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
