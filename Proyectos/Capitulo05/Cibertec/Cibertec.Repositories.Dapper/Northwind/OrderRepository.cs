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
    public class OrderRepository : Repository<Orders>, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString)
        {

        }

        public Orders GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //return connection.Get<Orders>(id);

                return connection.GetAll<Orders>().Where(
                            order => order.OrderId.Equals(id)).First();
            }
        }

        public bool Update(Orders order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute("update Orders " +
                                                "set CustomerId = @customerId, " +
                                                "EmployeeId = @employeeId, " +
                                                "OrderDate = @orderDate, " +
                                                "RequiredDate = @requiredDate, " +
                                                "ShippedDate = @shippedDate, " +
                                                "ShipVia = @shipVia, " +
                                                "Freight = @freight, " +
                                                "ShipName = @shipName " +
                                                "where OrderId = @myId",
                                                new
                                                {
                                                    customerId = order.CustomerId,
                                                    employeeId = order.EmployeeId,
                                                    orderDate = order.OrderDate,
                                                    requiredDate = order.RequiredDate,
                                                    shippedDate = order.ShippedDate,
                                                    shipVia = order.ShipVia,
                                                    freight = order.Freight,
                                                    shipName = order.ShipName,
                                                    myId = order.OrderId
                                                });
                return Convert.ToBoolean(result);
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute("delete from Orders " +
                                                "where OrderID = @myid",
                                                new { myid = id });

                return Convert.ToBoolean(result);
            }
        }
    }
}
