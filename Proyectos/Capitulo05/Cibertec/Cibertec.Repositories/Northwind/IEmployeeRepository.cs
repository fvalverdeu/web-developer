﻿using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Northwind
{
    public interface IEmployeeRepository: IRepository<Employees>
    {
        Employees GetById(int id);
        int Insert(Employees employee);
        bool Update(Employees employee);
        bool Delete(int id);
    }
}
