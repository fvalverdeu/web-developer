using Cibertec.Models;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unit;
        public CustomerController(IUnitOfWork unit)
        {
            //_unit = new NorthwindUnitOfWork(ConfigurationManager.
            //                    ConnectionStrings["NorthwindConnection"].ToString());
            _unit = unit;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(_unit.Customers.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            if (ModelState.IsValid)
            {
                _unit.Customers.Insert(customer);
                return RedirectToAction("Index");
            }
            return View(customer);            
        }

        public ActionResult Edit(string id)
        {
            return View(_unit.Customers.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Customers customer)
        {
            if (_unit.Customers.Update(customer)) return RedirectToAction("Index");
            return View(customer);
        }

        public ActionResult Delete(String id)
        {
            return View(_unit.Customers.GetById(id));
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(String id)
        {
            if (_unit.Customers.Delete(id)) return RedirectToAction("Index");
            return View(_unit.Customers.GetById(id));
        }

        public ActionResult Details(string id)
        {
            return View(_unit.Customers.GetById(id));
        }

    }
}