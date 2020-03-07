using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class CustomerRepository: Repository<Customers>, ICustomerRepository
    {
        public CustomerRepository(string connectionString): base(connectionString)
        {

        }

        public Customers GetById(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //return connection.Get<Customers>(id);

                return connection.GetAll<Customers>().Where(
                            customer => customer.CustomerId.Equals(id)).First();
            }
        }

        public bool Update(Customers customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute("update Customers " +
                                                "set CompanyName = @company, " +
                                                "ContactName = @contact, " +
                                                "City = @city, " +
                                                "Country = @country, " +
                                                "Phone = @phone " +
                                                "where CustomerID = @myId",
                                                new
                                                {
                                                    company = customer.CompanyName,
                                                    contact = customer.ContactName,
                                                    city = customer.City,
                                                    country = customer.Country,
                                                    phone = customer.Phone,
                                                    myId = customer.CustomerId
                                                });
                return Convert.ToBoolean(result);
            }
        }

        public bool Delete(String id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute("delete from Customers " +
                                                "where CustomerID = @myid",
                                                new { myid = id });

                return Convert.ToBoolean(result);
            }
        }

    }
}
