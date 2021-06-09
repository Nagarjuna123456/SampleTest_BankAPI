using SampleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest.Repository
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetCustomers();
        Customer Logintocustomer(string email   , string password);

        Customer AddCustomer(Customer add);
        void UpdateCustomer(Customer update);
        void DeleteCustomer(int id);
        void EditProfile(string customerid,string customername,string email,string dob);

    }
}
