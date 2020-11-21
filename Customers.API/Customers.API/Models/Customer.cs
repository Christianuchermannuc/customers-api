using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.API.Models
{
    public class Customer
    {
        public Customer(int id, int year, int numberOfOwners, string type)
        {
            Id = id;
            Year = year;
            NumberOfOwners = numberOfOwners;
            Type = type;
        }
        public int Id { get; set; }
        public int Year { get; set; }
        public int NumberOfOwners { get; set; }
        public string Type { get; set; }
    }
}
