using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.DataSource;
using HMS.Repository.Interface;

namespace HMS.Repository.Models
{
    public class Customer:ICustomer
    {
        public Customer()
        {
            
        }

        public List<HMS.ModelCore.Customer> GetCustomers()
        {
            AdventureWorks2012Entities Entities = new AdventureWorks2012Entities();
            return Entities.Customers.ToList().Select(customer => new ModelCore.Customer()
            {
                CustomerId = customer.CustomerID, CustomerName = customer.ContactName
            }).ToList();
        }

        public void UpdateCustomer(DataSource.Customer customer)
        {
            
        }

        public void DeleteCustomer(int customerId)
        {
            
        }

    }
}
