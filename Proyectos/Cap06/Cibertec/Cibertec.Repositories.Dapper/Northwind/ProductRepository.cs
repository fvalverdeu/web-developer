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
    public class ProductRepository : Repository<Products>, IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {

        }

        public Products GetById(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //return connection.Get<Products>(id);

                return connection.GetAll<Products>().Where(
                            product => product.ProductId.Equals(id)).First();
            }
        }

        public bool Update(Products product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute("update Products " +
                                                "set ProductName = @productName, " +
                                                "SupplierId = @supplierId, " +
                                                "CategoryId = @categoryId, " +
                                                "UnitPrice = @unitPrice, " +
                                                "QuantityPerUnit = @quantityPerUnit, " +
                                                "Discontinued = @discontinued, " +
                                                "where ProductID = @myId",
                                                new
                                                {
                                                    productName = product.ProductName,
                                                    supplierId = product.SupplierId,
                                                    categoryId = product.CategoryId,
                                                    unitPrice = product.UnitPrice,
                                                    quantityPerUnit = product.QuantityPerUnit,
                                                    discontinued = product.Discontinued,
                                                    myId = product.ProductId
                                                });
                return Convert.ToBoolean(result);
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute("delete from Products " +
                                                "where ProductID = @myid",
                                                new { myid = id });

                return Convert.ToBoolean(result);
            }
        }

    }
}
