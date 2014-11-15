using System.Collections.Generic;

namespace HMS.Repository.Interface
{
    interface ICustomer
    {
        List<HMS.ModelCore.Customer> GetCustomers();

        void UpdateCustomer(HMS.DataSource.Customer customer);

        void DeleteCustomer(int customerId);


    }
}
