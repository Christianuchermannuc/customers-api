using EventFunction.Entities;
using EventFunction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventFunction.Repositories
{

    public interface IEventRepository
    {
        void SaveEvent(CustomerEvent ce);
    }

    public class EventRepository : IEventRepository
    {
        private readonly CustomerEventContext _customerEventContext;

        public EventRepository(CustomerEventContext customerEventContext)
        {
            _customerEventContext = customerEventContext;
        }

        public void SaveEvent(CustomerEvent ce)
        {
            var newEvent = new CustomerEventEF();
            newEvent.CustomerId = ce.Id;
            newEvent.DateCreated = ce.DateCreated;
            newEvent.RequestType = ce.RequestType;

            _customerEventContext.CustomerEvents.Add(newEvent);
            _customerEventContext.SaveChanges();

        }
    }
}
