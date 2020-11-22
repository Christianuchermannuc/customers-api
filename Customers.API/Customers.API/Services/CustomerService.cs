using Customers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.API.Services
{
    public interface ICustomerService
    {
        Task<GenericRespons<Customer>> AddCustomer(Customer customer);
        Task<GenericRespons<IEnumerable<Customer>>> GetCustomers();
    }
    public class CustomerService : ICustomerService
    {
        ICosmosDbService _cosmosDbService;
        public CustomerService(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }
        public async Task<GenericRespons<Customer>> AddCustomer(Customer customer)
        {
            var newCustomer = new Customer("Toro", new CustomerType().GetCustomerTypeList().First(item => item.Id == 2).TypeName, 1989, 100, 500990);

            await _cosmosDbService.AddItemAsync(newCustomer);       

            var respons = new GenericRespons<Customer>();
            respons.Status = 200;
            respons.Payload = newCustomer;
            return respons;
        }

        public async Task<GenericRespons<IEnumerable<Customer>>> GetCustomers()
        {
            var customersList = await _cosmosDbService.GetItemsAsync("SELECT * FROM c");
            var respons = new GenericRespons<IEnumerable<Customer>>();
            respons.Status = 200;
            respons.Payload = customersList;
            return respons;
        }
    }
}
