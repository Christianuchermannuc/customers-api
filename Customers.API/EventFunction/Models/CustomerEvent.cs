using System;
using System.Collections.Generic;
using System.Text;

namespace EventFunction.Models
{
    public class CustomerEvent
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string RequestType { get; set; }
    }
}
