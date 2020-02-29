using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unit;

        public CustomerController()
        {
            _unit = new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings[
                "NorthwindConnection"].ToString());
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View(_unit.Customers.GetList());
        }
    }
}