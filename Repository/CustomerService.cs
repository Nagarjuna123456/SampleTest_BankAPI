using SampleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest.Repository
{
    public class CustomerService : ICustomer
    {
        SampleTestContext dbcontext;

        public CustomerService(SampleTestContext _db)
        {
            dbcontext = _db;
        }

        public Customer AddCustomer(Customer add)
        {
            if (add != null)
            {
                dbcontext.customers.Add(add);
                dbcontext.SaveChanges();
                return add;
            }
            return null;

        }

        public void DeleteCustomer  (int id)
        {
            var delete = dbcontext.customers.FirstOrDefault(d => d.ID == id);
            if (delete != null)
            {
                dbcontext.customers.Remove(delete);
                dbcontext.SaveChanges();
            }
        }

        public void EditProfile(string customerid, string customername, string email, string dob)
        {
            var edtdata = dbcontext.customers.Where(c => c.CustomerID == customerid).SingleOrDefault();
            if(edtdata  != null)
            {
                edtdata.CustomerName = customername;
                edtdata.Email = email;
                edtdata.DOB = dob;
            }
            dbcontext.customers.Update(edtdata);
            dbcontext.SaveChanges();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = dbcontext.customers.ToList();
            //var customers = customerlist.ToList();
            return customers;
        }

        public Customer Logintocustomer(string email, string password)
        {
            var customer = dbcontext.customers.FirstOrDefault(c => c.Email == email && c.Password == password);
            //var customer = customerlist.FirstOrDefault(c => c.CustomerID == id && c.Password == password);
            return customer;
        }

        public void UpdateCustomer(Customer update)
        {
            dbcontext.customers.Update(update);
            dbcontext.SaveChanges();
        }

        //private List<Customer> customerlist = new List<Customer>()
        //{
        //    new Customer()
        //    {
        //        CustomerID ="1a1b",
        //        CustomerName="Nagesh",
        //        Email ="nagesh@mail.com",
        //        Password ="nagesh@123",
        //        DOB="1989-10-12"
        //    },
        //    new Customer()
        //    {
        //        CustomerID ="2a2b",
        //        CustomerName="Naveen",
        //        Email ="naveen@mail.com",
        //        Password ="naveen@123",
        //        DOB="1988-12-12"
        //    }


        //};
    }
}
