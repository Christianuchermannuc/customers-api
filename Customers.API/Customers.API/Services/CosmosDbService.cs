using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.API.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Customers.API.Models;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Fluent;
    using Microsoft.Extensions.Configuration;

    public interface ICosmosDbService
    {
        Task<IEnumerable<Customer>> GetItemsAsync(string query);
        Task<Customer> GetItemAsync(string id);
        Task AddItemAsync(Customer item);
        Task UpdateItemAsync(string id, Customer item);
        Task<ItemResponse<Customer>> DeleteItemAsync(string id);
    }

    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(Customer item)
        {
            await this._container.CreateItemAsync<Customer>(item, new PartitionKey(item.Id));
        }

        public async Task<ItemResponse<Customer>> DeleteItemAsync(string id)
        {
           return await this._container.DeleteItemAsync<Customer>(id, new PartitionKey(id));
        }

        public async Task<Customer> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<Customer> response = await this._container.ReadItemAsync<Customer>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<Customer>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Customer>(new QueryDefinition(queryString));
            List<Customer> results = new List<Customer>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, Customer item)
        {
            await this._container.UpsertItemAsync<Customer>(item, new PartitionKey(id));
        }
    }
}

