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
        Task<GenericRespons<string>> DeleteCustomer(string id);
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
            await _cosmosDbService.AddItemAsync(customer);       

            var respons = new GenericRespons<Customer>();
            respons.Status = 200;
            respons.Payload = customer;
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

        public async Task<GenericRespons<string>> DeleteCustomer(string id)
        {
            var cosmosRespons = await _cosmosDbService.DeleteItemAsync(id);
            var respons = new GenericRespons<string>();
            respons.Status = 200;
            respons.Payload = "Deleted";
            return respons;
        }
    }
}
