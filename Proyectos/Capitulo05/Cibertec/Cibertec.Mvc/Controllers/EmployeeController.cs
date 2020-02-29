using Cibertec.UnitOfWork;
using Cibertec.Models;
using Cibertec.Repositories.Dapper.Northwind;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unit;
        public EmployeeController(IUnitOfWork unit)
        {
            //_unit = new NorthwindUnitOfWork(
            //    ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
            _unit = unit;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View(_unit.Employees.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _unit.Employees.Insert(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            return View(_unit.Employees.GetById(id));
        }
    }
}