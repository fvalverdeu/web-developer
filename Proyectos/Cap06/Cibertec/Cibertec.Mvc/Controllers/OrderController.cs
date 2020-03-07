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
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unit;

        public OrderController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        // GET: Order
        public ActionResult Index()
        {
            return View(_unit.Orders.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Orders order)
        {
            if (ModelState.IsValid)
            {
                _unit.Orders.Insert(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public ActionResult Edit(int id)
        {
            return View(_unit.Orders.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Orders order)
        {
            if (_unit.Orders.Update(order)) return RedirectToAction("Index");
            return View(order);
        }

        public ActionResult Delete(int id)
        {
            return View(_unit.Orders.GetById(id));
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            if (_unit.Orders.Delete(id)) return RedirectToAction("Index");
            return View(_unit.Orders.GetById(id));
        }

        public ActionResult Details(int id)
        {
            return View(_unit.Orders.GetById(id));
        }
    }
}