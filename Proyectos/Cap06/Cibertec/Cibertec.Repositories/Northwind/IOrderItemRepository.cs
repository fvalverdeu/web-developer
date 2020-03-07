using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Northwind
{
    public interface IOrderItemRepository: IRepository<OrderItem>
    {
        OrderItem GetById(int id);
        bool Update(OrderItem orderItem);
        bool Delete(int id);
    }
}
