using Cibertec.Repositories.Northwind;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class NorthwindUnitOfWork: IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Customers = new CustomerRepository(connectionString);
        }

        public ICustomerRepository Customers
        {
            get;
            private set;
        }
    }
}
