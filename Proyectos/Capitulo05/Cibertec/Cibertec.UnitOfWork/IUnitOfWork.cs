using Cibertec.Repositories.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IEmployeeRepository Employees { get; }
        IOrderRepository Orders { get; }
        //IOrderItemRepository OrderItem { get; }
        //ISupplierRepository Supplier { get; }
        //IProductRepository Product { get; }
        //IUserRepository User { get; }
    } 
}
