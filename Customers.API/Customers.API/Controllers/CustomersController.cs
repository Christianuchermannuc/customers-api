using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.API.Models;
using Customers.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customerList = new List<Customer>();
            customerList.Add(new Customer(1,"BKK", new CustomerType().GetCustomerTypeList().First(item => item.Id == 1).TypeName, 1980, 2,12002002));
            customerList.Add(new Customer(2,"DNB", new CustomerType().GetCustomerTypeList().First(item => item.Id == 2).TypeName, 1990, 20, 43434343));
            customerList.Add(new Customer(3,"SPV", new CustomerType().GetCustomerTypeList().First(item => item.Id == 1).TypeName, 2000, 9 ,10000000));
            customerList.Add(new Customer(4,"Test", new CustomerType().GetCustomerTypeList().First(item => item.Id == 3).TypeName, 2005, 10, 4000000));
            customerList.Add(new Customer(5,"Test2", new CustomerType().GetCustomerTypeList().First(item => item.Id == 2).TypeName, 1989, 100, 5000));

            return Ok(customerList);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer newCustomer)
        {
            var result =   _customerService.AddCustomer(newCustomer);
            if (result.Status == 200)
            {
                return Ok(result.Payload);
            }
            return BadRequest();
        }

    }
}
