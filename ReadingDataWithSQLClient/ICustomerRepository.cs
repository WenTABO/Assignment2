using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDataWithSQLClient
{
    public interface ICustomerRepository
    {
    
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Customer> GetSpecificCustomer(int id);
        public Customer GetCustomerByName(string customerName);

        IEnumerable<Customer> ReturnCustomerPage(int limit, int offset);



    }
}
