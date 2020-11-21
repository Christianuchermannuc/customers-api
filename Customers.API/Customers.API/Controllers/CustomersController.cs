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
            customerList.Add(new Customer(1, 1980, 2, new CustomerType().GetCustomerTypeList().First(item => item.Id == 1).TypeName,12002002));
            customerList.Add(new Customer(2, 1990, 20, new CustomerType().GetCustomerTypeList().First(item => item.Id == 2).TypeName,43434343));
            customerList.Add(new Customer(3, 2000, 9, new CustomerType().GetCustomerTypeList().First(item => item.Id == 1).TypeName,10000000));
            customerList.Add(new Customer(4, 2005, 10, new CustomerType().GetCustomerTypeList().First(item => item.Id == 3).TypeName,4000000));
            customerList.Add(new Customer(5, 1989, 100, new CustomerType().GetCustomerTypeList().First(item => item.Id == 2).TypeName,5000));

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
