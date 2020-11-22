using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.API.Models
{
    public class GenericRespons<T>
    {
        public T Payload { get; set; }
        public int Status { get; set; }
        public string ErrorDescription { get; set; }
    }
}
