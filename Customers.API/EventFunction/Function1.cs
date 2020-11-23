using System;
using EventFunction.Entities;
using EventFunction.Models;
using EventFunction.Repositories;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EventFunction
{
    public  class Function1
    {
        IEventRepository _eventRepository;
        
        public Function1(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [FunctionName("Function1")]
        public   void Run([ServiceBusTrigger("customerevents", Connection = "serviceBusConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var customerEvent = JsonConvert.DeserializeObject<CustomerEvent>(myQueueItem);
            _eventRepository.SaveEvent(customerEvent);

        }
    }
}
