using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class EmployeeRepository: Repository<Employees>, IEmployeeRepository
    {
        public EmployeeRepository(string connectionString): base(connectionString)
        {

        }

        public Employees GetEmployees()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Employees>()
            }
        }
    }
}
