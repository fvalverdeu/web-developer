using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Northwind
{
    public interface ISupplierRepository: IRepository<Suppliers>
    {
        Suppliers GetById(int id);
        bool Update(Suppliers suppliers);
        bool Delete(int id);
    }
}
