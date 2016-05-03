using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using RentBoat.Autofac;
using RentBoat.CommandStack;
using RentBoat.QueryStack;
using RentBoat.WebSite.Areas.Customer.WorkerServices;

namespace RentBoat.WebSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(RentBoat.WebSite.Areas.Customer.Controllers.BoatController).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();



            builder.RegisterType<BoatWorkerService>();
            // Set the dependency resolver to be Autofac.
            AutofacConfig.Configure(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            //container.Resolve<IQueryRentBoatContexttDatabaseInitializer>().Initialize();
        }
    }
}
