using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentBoat.WebSite.Areas.Customer.Models;

namespace RentBoat.WebSite.Test.Rent
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class As_a_user_I_can_see_a_list_of_registred_boats_and_the_customer_who_rented_the_boat:TestBase
    {
        [TestMethod]
        public void WorksCorrectly()
        {
            var boat =WorkerService.Register(new RegisterNewBoatInputModel(){ BoatName = "Boat 1", HourlyRate = 5000});
            WorkerService.RequestRentingOut(new RentOutInputModel()
            {
                BoatNumber = boat.BoatNumber,
                CustomerName = "Customer 1"
            });

            var info = WorkerService.Index().First(x => x.BoatNumber == boat.BoatNumber);
            info.CustomerName.Should().Be("Customer 1");

        }

    }
}
