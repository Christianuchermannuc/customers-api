using Newtonsoft.Json;
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
            Id = Guid.NewGuid().ToString();
        }
        public Customer(string name, string type, int year, int numberOfOwners, int shareCapital)
        {
            Id= Guid.NewGuid().ToString();
            Name = name;
            Type = type;
            Year = year;
            NumberOfOwners = numberOfOwners;           
            ShareCapital = shareCapital;            
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "numberOfOwners")]
        public int NumberOfOwners { get; set; }


        [JsonProperty(PropertyName = "shareCapital")]
        public int ShareCapital { get; set; }
    }
}
