using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.API.Models
{
    public class CustomerEvent
    {

        public CustomerEvent(string id, string requestType)
        {
            Id = id;
            RequestType = requestType;
            DateCreated = DateTime.Now;
        }
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string RequestType { get; set; }
    }
}
