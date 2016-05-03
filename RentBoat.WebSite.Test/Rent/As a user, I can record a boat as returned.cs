using System;
using System.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentBoat.WebSite.Areas.Customer.Models;
using RentBoat.WebSite.Areas.Customer.WorkerServices;

namespace RentBoat.WebSite.Test.Rent
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class As_a_user__I_can_record_a_boat_as_returned : TestBase
    {
        //I provide a boat number and request marking it as returned. If the operation is successful, I get back the rent time and price. If unsuccessful I get informed of the reason. Only the rented out boat can be returned.

        [TestMethod]
        public void SuccessfulReturnTimeAndPrice()
        {

            var boat = WorkerService.Register(new RegisterNewBoatInputModel() { BoatName = "boat1", HourlyRate = 100000 });

            WorkerService.RequestRentingOut(new RentOutInputModel()
            {
                BoatNumber = boat.BoatNumber,
                CustomerName = "Customer1"
            });

            Thread.Sleep(3000);

            var info = WorkerService.MarkAsRenturned(new ReturnBoatInputModel() { BoatNumber = boat.BoatNumber });
            info.Price.Should().Be(83.33m);
            info.RentTime.Should().BeCloseTo(new TimeSpan(0, 0, 3));
        }

        [TestMethod]
        public void If_unsuccessful_I_get_informed_of_the_reason()
        {
            WorkerService.Invoking(x => x.MarkAsRenturned(new ReturnBoatInputModel()
            {
                BoatNumber = -1,
            })).ShouldThrow<Exception>();
        }
    }
}
