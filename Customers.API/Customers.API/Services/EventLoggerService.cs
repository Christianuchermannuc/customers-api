using Customers.API.Models;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.API.Services
{

    public interface IEventLoggerService
    {
        Task LoggEvent(CustomerEvent customerEvent);
    }
    public class EventLoggerService : IEventLoggerService
    {        
        private readonly QueueClient _queueClient;
        private const string queueName = "customerevents";
        public EventLoggerService(string serviceBusConnectionString)
        {          
            _queueClient = new QueueClient(serviceBusConnectionString, queueName);
        }

        public async Task LoggEvent(CustomerEvent customerEvent)
        {
            var data = JsonConvert.SerializeObject(customerEvent);
            var message = new Message(Encoding.UTF8.GetBytes(data));

            await _queueClient.SendAsync(message);
        }
    }
}
