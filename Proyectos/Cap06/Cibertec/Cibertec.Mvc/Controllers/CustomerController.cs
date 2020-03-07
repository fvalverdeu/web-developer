using log4net;
using Cibertec.Models;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cibertec.Mvc.ActionFilters;

namespace Cibertec.Mvc.Controllers
{
    // [ErrorActionFilter]
    public class CustomerController : BaseController
    {
        // private readonly IUnitOfWork _unit;
        public CustomerController(ILog log, IUnitOfWork unit): base(log, unit)
        {
            //_unit = new NorthwindUnitOfWork(ConfigurationManager.
            //                    ConnectionStrings["NorthwindConnection"].ToString());
            //_unit = unit;
        }

        public ActionResult Error()
        {
            throw new System.Exception("Test error");
        }

        // GET: Customer
        public ActionResult Index()
        {
            _log.Info("Ejecución de Customer Controller Ok");
            return View(_unit.Customers.GetList());
        }

        public /*ActionResult*/ PartialViewResult Create()
        {
            return PartialView("_Create", new Customers());
        }

        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            if (ModelState.IsValid)
            {
                _unit.Customers.Insert(customer);
                return RedirectToAction("Index");
            }
            // return View(customer);            
            return PartialView("_Create", customer);
        }

        public /*ActionResult*/ PartialViewResult Edit(string id)
        {
            // return View(_unit.Customers.GetById(id));
            return PartialView("_Edit", _unit.Customers.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Customers customer)
        {
            if (_unit.Customers.Update(customer)) return RedirectToAction("Index");
            // return View(customer);
            return PartialView(customer);
        }

        public /*ActionResult*/ PartialViewResult Delete(String id)
        {
            // return View(_unit.Customers.GetById(id));
            return PartialView("_Delete", _unit.Customers.GetById(id));
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(String id)
        {
            if (_unit.Customers.Delete(id)) return RedirectToAction("Index");
            // return View(_unit.Customers.GetById(id));
            return PartialView("_Delete", _unit.Customers.GetById(id));
        }

        public /*ActionResult*/ PartialViewResult Details(string id)
        {
            // return View(_unit.Customers.GetById(id));
            return PartialView("_Details", _unit.Customers.GetById(id));
        }

    }
}