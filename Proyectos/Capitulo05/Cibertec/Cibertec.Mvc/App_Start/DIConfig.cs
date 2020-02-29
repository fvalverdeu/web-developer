using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using Cibertec.UnitOfWork;
using Cibertec.Repositories.Dapper.Northwind;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;
using SimpleInjector.Integration.Web.Mvc;

namespace Cibertec.Mvc.App_Start
{
    public class DIConfig
    {
        public static void ConfigureInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<IUnitOfWork>(() => new NorthwindUnitOfWork(
                ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString()));

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}