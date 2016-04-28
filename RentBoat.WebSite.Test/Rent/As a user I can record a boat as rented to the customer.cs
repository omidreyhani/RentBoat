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
        [TestMethod]
        public void If_the_operation_is_successful_I_get_back_the_rent_time_and_price()
        {
            WorkerService.RequestRentingOut(new RentOutInputModel()
            {
               BoatNumber = 1,
               CustomerName = "Customer 1"
            });
        }

        [TestMethod]
        public void If_unsuccessful_I_get_informed_of_the_reason_Only_the_rented_out_boat_can_be_returned()
        {
            WorkerService.Invoking(x => x.RequestRentingOut(new RentOutInputModel()
            {
                BoatNumber = -1,
                CustomerName = "Customer 1"
            })).ShouldThrow<Exception>();
        }
    }
}
