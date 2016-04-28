using Autofac;
using RentBoat.CommandStack;
using RentBoat.QueryStack;

namespace RentBoat.Autofac
{
    public static class AutofacConfig
    {
        public static void Configure(ContainerBuilder builder)
        {
            // Register your MVC controllers.
       

            //builder.RegisterType<QueryRepository>().As<IQueryRepository>();
            //builder.RegisterType<ProductApi>().As<IProductApi>();
            ////builder.RegisterType<FakeProductApi>().As<IProductApi>();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            //builder.RegisterType<QuerySearchContextDatabaseInitializer>().As<IQuerySearchContextDatabaseInitializer>();
            //builder.RegisterType<SearchContextDatabaseInitializer>().As<ISearchContextDatabaseInitializer>();
            //builder.RegisterType<UpdateCommandHandler>().As<IUpdateCommandHandler>();


            builder.RegisterType<Repository>().As<IRepository>();
            builder.RegisterType<QueryRepository>().As<IQueryRepository>();

            builder.RegisterType<CommandRentBoatContextDatabaseInitializer>().As<ICommandRentBoatContextDatabaseInitializer>();
            




        }

        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            Configure(builder);
            return builder.Build();
        }

    }
}
