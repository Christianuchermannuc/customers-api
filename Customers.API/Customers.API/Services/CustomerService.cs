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
        IEventLoggerService _eventLoggerService;
        public CustomerService(ICosmosDbService cosmosDbService, IEventLoggerService eventLoggerService)
        {
            _cosmosDbService = cosmosDbService;
            _eventLoggerService = eventLoggerService;
        }
        public async Task<GenericRespons<Customer>> AddCustomer(Customer customer)
        {
            var respons = new GenericRespons<Customer>();

            var validate = ValidateNewCustomer(customer);

            if (!string.IsNullOrEmpty(validate))
            {
                respons.Status = 400;
                respons.Payload = customer;
                respons.ErrorDescription = validate;
                return respons;
            }

            await _cosmosDbService.AddItemAsync(customer);
            await _eventLoggerService.LoggEvent(new CustomerEvent(customer.Id, "NewCustomer"));

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
            await _eventLoggerService.LoggEvent(new CustomerEvent(id, "DeleteCustomer"));
            return respons;
        }

        private string IsYearInFuture(Customer customer)
        {
           if(DateTime.Now.Year < customer.Year)
            {
                return "Year cant be in the future. ";
            }

            return "";
        }

        private string LimitedLiabilityCompanyRules(Customer customer)
        {
            var responeString = "";
            if(customer.Type == "Limited liability company")
            {
                if (customer.ShareCapital < 30000)
                {
                    responeString = "Limited liability company should have minimum share capital 30000. ";
                }
                if (customer.NumberOfOwners < 1)
                {
                    responeString = responeString + "Limited liability company should have one or more owners. ";
                }
            }
            return responeString;
        }

        private string SoleProprietorshipRules(Customer customer)
        {
            var responeString = "";
            if (customer.Type == "Sole proprietorship")
            {
                
                if (customer.NumberOfOwners != 1)
                {
                    responeString = "Sole proprietorship should have only one owner. ";
                }
            }
            return responeString;
        }

        private string GeneralPartnershipRules(Customer customer)
        {
            var responeString = "";
            if (customer.Type == "General partnership")
            {

                if (customer.NumberOfOwners < 2)
                {
                    responeString = "General partnership should have only two or more owners. ";
                }
            }
            return responeString;
        }

        private string ValidateNewCustomer(Customer customer)
        {
            var responeString = "";
            responeString += IsYearInFuture(customer);
            responeString += LimitedLiabilityCompanyRules(customer);
            responeString += SoleProprietorshipRules(customer);
            responeString += GeneralPartnershipRules(customer);

            return responeString;

        }
    }
}
