using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
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

        public Employees GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Employees>().Where(
                    employee => employee.EmployeeId.Equals(id)).First();
            }
        }

        public bool Update(Employees employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(
                    "update Employees " +
                    "set FirstName = @firstName, " +
                    "set LastName = @lastName, " +
                    "set BirthDate = @birthDate, " +
                    "set City = @city, " +
                    "set ReportsTo = @reportsTo " +
                    "where EmployeeID = @employeeId",
                    new
                    {
                        firstName = employee.FirstName,
                        lastName = employee.LastName,
                        birthDate = employee.BirthDate,
                        city = employee.City,
                        reportsTo = employee.ReportsTo,
                        employeeId = employee.EmployeeId
                    }
                    );
                return Convert.ToBoolean(result);
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(
                    "delete from Employees " +
                    "where EmployeeID = @employeeId",
                    new { employeeId = id }
                    );
                return Convert.ToBoolean(result);
            }
        }

        public int Insert(Employees employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(
                    "insert into Employees (FirstName, LastName, BirthDate, " +
                    "City, ReportsTo) values (@firstName, @lastName, @birthDate, " +
                    "@city, @reportsTo)", 
                    new
                    {
                        firstName = employee.FirstName,
                        lastName = employee.LastName,
                        birthDate = employee.BirthDate,
                        city = employee.City,
                        reportsTo = employee.ReportsTo
                    }
                    );
                return Convert.ToInt32(result);
            }
        }

    }
}
