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
    public class OrderItemRepository: Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(string connectionString) : base(connectionString)
        {

        }

        public OrderItem GetById(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<OrderItem>().Where(
                    OrderItem => OrderItem.OrderId.Equals(id)).First();
            }
        }

        public bool Update(OrderItem OrderItem)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(
                    "update OrderItem " +
                    "set OrderId = @orderId, " +
                    "set ProductId = @productId, " +
                    "set UnitPrice = @unitPrice, " +
                    "set Quantity = @quantity, " +
                    "set Discount = @discount " +
                    "where OrderId = @orderId",
                    new
                    {
                        orderId = OrderItem.OrderId,
                        productId = OrderItem.ProductId,
                        unitPrice = OrderItem.UnitPrice,
                        quantity = OrderItem.Quantity,
                        discount = OrderItem.Discount
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
                    "delete from OrderItem " +
                    "where OrderItemID = @orderItemId",
                    new { orderItemId = id }
                    );
                return Convert.ToBoolean(result);
            }
        }
    }
}
