using RentBoat.CommandStack;
using RentBoat.WebSite.Areas.Customer.WorkerServices;
using RentBoatContext = RentBoat.CommandStack.RentBoatContext;

namespace RentBoat.WebSite.Test.Rent
{
    public class TestBase
    {
        protected BoatWorkerService WorkerService { get; set; }

        protected TestBase()
        {
            //RentBoatContextDatabaseInitializer boatContextDatabaseInitializer = new RentBoatContextDatabaseInitializer();
            //CommandRentBoatContextDatabaseInitializer commandRentBoatContextDatabaseInitializer = new CommandRentBoatContextDatabaseInitializer();
            //boatContextDatabaseInitializer.Initialize();
            //commandRentBoatContextDatabaseInitializer.Initialize();
            WorkerService = new BoatWorkerService(new Repository());
        }
    }
}