using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.API.Models
{
    public class CustomerType
    {
        public CustomerType()
        {

        }
        public  CustomerType(int id, string typeName)
        {
            Id = id;
            TypeName = typeName;

        }
        public int Id { get; set; }
        public string TypeName { get; set; }

        public IEnumerable<CustomerType> GetCustomerTypeList()
        {
            var customerTypeList = new List<CustomerType>();
            customerTypeList.Add(new CustomerType(1, "Limited liability company"));
            customerTypeList.Add(new CustomerType(2, "Sole proprietorship"));
            customerTypeList.Add(new CustomerType(3, "General partnership" ));

            return customerTypeList;
        }
    }
}
