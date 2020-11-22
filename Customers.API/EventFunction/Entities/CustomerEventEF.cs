using System;
using System.Collections.Generic;
using System.Text;

namespace EventFunction.Entities
{
    public class CustomerEventEF
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateCreated { get; set; }
        public string RequestType { get; set; }
        public string CustomerId { get; set; }
    }
}
