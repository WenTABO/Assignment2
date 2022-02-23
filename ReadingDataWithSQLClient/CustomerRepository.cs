using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDataWithSQLClient
{
    public class CustomerRepository : ICustomerRepository
    {
        //This methode will read and print  specific information for all the customers in DB customers 
        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {

                using SqlConnection connection = new SqlConnection(DbConfig.Config());
                connection.Open();

                var sql = "SELECT * FROM Customer";
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine($"----------------------------------------------------------------------------------------------------");
                Console.WriteLine($"ID FirstName tLast Name  Country  PostalCode  Phone\t\tEmail\t\t");
                Console.WriteLine($"-----------------------------------------------------------------------------------------------------");
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    {
                        customer.customerId = reader.GetInt32(0);
                        customer.FirstName = reader.GetString(1);
                        customer.LastName = reader.GetString(2);
                        customer.Country = reader[7] as string;
                        customer.PostalCode = reader[8] as string;
                        customer.Phone = reader[9] as string;
                        customer.Email = reader.GetString(11);

                        Console.WriteLine($"{customer.customerId}\t {customer.FirstName}\t {customer.LastName}\t\t{customer.Country}\t\t {customer.PostalCode}\t\t{customer.Phone}\\t\tt{customer.Email}\t");
                    };

                    customers.Add(customer);
                }
            }
            catch (SqlException ex)

            {
                Console.WriteLine(ex.Message);
            }

            return customers;

        }

         //This methode will read and print  specific information for an specific customers in DB customers 
        public IEnumerable<Customer> GetSpecificCustomer(int id)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                Customer customer = new Customer();
                using SqlConnection connection = new SqlConnection(DbConfig.Config());
                connection.Open();

                var sql = "SELECT *  FROM Customer WHERE CustomerId = @Id";
                using SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                using SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine($"----------------------------------------------------------------------------------------------------");
                Console.WriteLine($"ID FirstName tLast Name  Country  PostalCode  Phone\t\tEmail\t\t");
                Console.WriteLine($"----------------------------------------------------------------------------------------------------");
                while (reader.Read())
                {
                        customer.customerId = reader.GetInt32(0);
                        customer.FirstName = reader.GetString(1);
                        customer.LastName = reader.GetString(2);
                        customer.Country = reader[7] as string;
                        customer.PostalCode = reader[8] as string;
                        customer.Phone = reader[9] as string;
                        customer.Email = reader.GetString(11);

                        Console.WriteLine($"{customer.customerId} {customer.FirstName} {customer.LastName}\t\t{customer.Country}\t\t {customer.PostalCode}\t\t{customer.Phone}\\t\tt{customer.Email}\t");
                   
                    customers.Add(customer);
                }
            }
            catch (SqlException ex)

            {
                Console.WriteLine(ex.Message);
            }

            return customers;

        }

        public Customer GetCustomerByName(string customerName)
        {

            Customer customer = new Customer();
            var sql = "SELECT * FROM Customer WHERE FirstName LIKE '@FirstName'";
            try
            {

                using SqlConnection connection = new SqlConnection(DbConfig.Config());
                {
                    connection.Open();
                    {
                        using SqlCommand command = new SqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@FirstName", customerName);
                        using SqlDataReader reader = command.ExecuteReader();
                        {
                            while (reader.Read())
                            {
                                customer.customerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Company = reader[3] as string;
                                customer.Address = reader.GetString(4);
                                customer.City = reader.GetString(5);
                                customer.State = reader.GetString(6); ;
                                customer.Country = reader[7] as string;
                                customer.PostalCode = reader[8] as string;
                                customer.Phone = reader[9] as string;
                                customer.Fax = reader[10] as string;
                                customer.Email = reader.GetString(11);


                                Console.WriteLine($"{customer.customerId} {customer.FirstName} {customer.LastName}{customer.Company}{customer.Address}");
                            }
                        }
                    }
                }
            }


            catch (SqlException ex)

            {
                Console.WriteLine(ex.Message);
            }

            return customer;

        }

        public IEnumerable<Customer> ReturnCustomerPage(int limit, int offset)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                Customer customer = new Customer();
                using SqlConnection connection = new SqlConnection(DbConfig.Config());
                connection.Open();

                string sql = "SELECT c.CustomerId, c.FirstName, c.LastName, c.Country, c.PostalCode,c.Phone, c.Email FROM Customer as c "
                   + "ORDER BY c.CustomerId "
                   + "OFFSET(@limit)  ROWS"
                   + "FETCH NEXT @offset ROWS ONLY";
                using SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@limit", limit);
                command.Parameters.AddWithValue("@offset", offset);
                using SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine($"----------------------------------------------------------------------------------------------------");
                Console.WriteLine($"ID FirstName tLast Name  Country  PostalCode  Phone\t\tEmail\t\t");
                Console.WriteLine($"----------------------------------------------------------------------------------------------------");
                while (reader.Read())
                {
                    customer.customerId = reader.GetInt32(0);
                    customer.FirstName = reader.GetString(1);
                    customer.LastName = reader.GetString(2);
                    customer.Country = reader[7] as string;
                    customer.PostalCode = reader[8] as string;
                    customer.Phone = reader[9] as string;
                    customer.Email = reader.GetString(11);

                    Console.WriteLine($"{customer.customerId} {customer.FirstName} {customer.LastName}\t\t{customer.Country}\t\t {customer.PostalCode}\t\t{customer.Phone}\\t\tt{customer.Email}\t");

                    customers.Add(customer);
                }
            }
            catch (SqlException ex)

            {
                Console.WriteLine(ex.Message);
            }

            return customers;

        }
    }
}
