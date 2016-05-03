using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentBoat.WebSite.Areas.Customer.Models;
using RentBoat.WebSite.Areas.Customer.WorkerServices;

namespace RentBoat.WebSite.Test.Rent
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class As_a_user_I_can_record_a_boat_as_rented_to_the_customer:TestBase
    {
        //Acceptance criteria: I provide a boat number and customer name, and request renting out. If unsuccessful I get informed of the reason. If the boat is currently rented out, it cannot be rented out.
        [TestMethod]
        public void If_the_operation_is_successful_I_get_back_the_rent_time_and_price()
        {
            var boat = WorkerService.Register(new RegisterNewBoatInputModel() { BoatName = "boat1", HourlyRate = 100000 });
            WorkerService.RequestRentingOut(new RentOutInputModel()
            {
               BoatNumber = boat.BoatNumber,
               CustomerName = "Customer 1"
            });
        }

        [TestMethod]
        public void If_unsuccessful_I_get_informed_of_the_reason_Only_the_rented_out_boat_can_be_returned()
        {
            var boat = WorkerService.Register(new RegisterNewBoatInputModel() { BoatName = "boat1", HourlyRate = 1 });

            WorkerService.RequestRentingOut(new RentOutInputModel()
            {
                BoatNumber = boat.BoatNumber,
                CustomerName = "Customer1"
            });

            WorkerService.Invoking(x => x.RequestRentingOut(new RentOutInputModel()
            {
                BoatNumber = boat.BoatNumber,
                CustomerName = "Customer 2"
            })).ShouldThrow<Exception>().WithMessage("Boat is already rented");
        }
    }
}
