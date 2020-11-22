using System;
using EventFunction.Entities;
using EventFunction.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EventFunction
{
    public  class Function1
    {
        IRepository _repository;
        
        public Function1(IRepository repository)
        {
            _repository = repository;
        }

        [FunctionName("Function1")]
        public   void Run([ServiceBusTrigger("customerevents", Connection = "serviceBusConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var customerEvent = JsonConvert.DeserializeObject<CustomerEvent>(myQueueItem);
           _repository.SaveEvent(customerEvent);

        }
    }
}
