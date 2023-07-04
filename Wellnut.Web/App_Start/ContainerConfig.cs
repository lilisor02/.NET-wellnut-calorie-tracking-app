using Autofac;
using Autofac.Integration.Mvc;
using DotNetOpenAuth.OAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using Wellnut.Data;
using Wellnut.Data.Services;
using Wellnut.Web.Controllers;

namespace Wellnut.Web.App_Start
{
    public class ContainerConfig
    {

        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlUserData>()
                .As<IUserData>()
                .SingleInstance();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlFoodData>()
                .As<IFoodData>()
                .SingleInstance();

            builder.RegisterType<WellnutContext>()
                .As<WellnutContext>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}