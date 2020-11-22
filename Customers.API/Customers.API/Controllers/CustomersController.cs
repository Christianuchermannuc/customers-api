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
        public async Task<IActionResult> Get()
        {
            var customerListRespons = await _customerService.GetCustomers();
            return Ok(customerListRespons.Payload);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer newCustomer)
        {
            var result = await _customerService.AddCustomer(newCustomer);
            if (result.Status == 200)
            {
                return Ok(result.Payload);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            try
            {
                var respons = await _customerService.DeleteCustomer(id);
            }
            catch (Exception)
            {

                return BadRequest("Could not delete customer");
            }

            return Ok();
        }

    }
}
