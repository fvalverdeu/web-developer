using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Northwind
{
    public interface IProductRepository: IRepository<Products>
    {
        Products GetById(int id);
        bool Update(Products products);
        bool Delete(int id);
    }
}
