using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Northwind
{
    public interface ICustomerRepository: IRepository<Customers>
    {
        Customers GetById(String id);
        bool Update(Customers customer);
        bool Delete(String id);
    }
}