using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Northwind
{
    public interface IUserRepository: IRepository<User>
    {
        User GetById(String id);
        bool Update(User user);
        bool Delete(String id);
    }
}
