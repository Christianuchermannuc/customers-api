using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.API.Models
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(int id,string name, string type, int year, int numberOfOwners, int shareCapital)
        {
            Id = id;
            Name = name;
            Type = type;
            Year = year;
            NumberOfOwners = numberOfOwners;           
            ShareCapital = shareCapital;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
        public int Year { get; set; }
        public int NumberOfOwners { get; set; }
       
        public int ShareCapital { get; set; }
    }
}
