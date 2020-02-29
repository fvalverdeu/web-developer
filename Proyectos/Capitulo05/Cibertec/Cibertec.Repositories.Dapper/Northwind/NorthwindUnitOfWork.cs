using Cibertec.Repositories.Northwind;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        { 
            Customers = new CustomerRepository(connectionString);
            Employees = new EmployeeRepository(connectionString);
            Orders = new OrderRepository(connectionString);
            OrderItems = new OrderItemRepository(connectionString);
        }

        public ICustomerRepository Customers
        {
            get;
            private set;
        }

        public IEmployeeRepository Employees
        {
            get;
            private set;
        }

        public IOrderRepository Orders
        {
            get;
            private set;
        }

        public IOrderItemRepository OrderItems
        {
            get;
            private set;
        }

        public ISupplierRepository Suppliers
        {
            get;
            private set;
        }

        public IUserRepository Users
        {
            get;
            private set;
        }

        public IProductRepository Product
        {
            get;
            private set;
        }
    }
}
