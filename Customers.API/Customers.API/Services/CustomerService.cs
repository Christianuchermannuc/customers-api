using Customers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.API.Services
{
    public interface ICustomerService
    {
        GenericRespons<Customer> AddCustomer(Customer customer);
    }
    public class CustomerService : ICustomerService
    {
        public GenericRespons<Customer> AddCustomer(Customer customer)
        {
            var newCustomer = new Customer(6,"Toro", new CustomerType().GetCustomerTypeList().First(item => item.Id == 2).TypeName, 1989, 100, 500990);

            var respons = new GenericRespons<Customer>();
            respons.Status = 200;
            respons.Payload = newCustomer;
            return respons;
        }
    }
}
