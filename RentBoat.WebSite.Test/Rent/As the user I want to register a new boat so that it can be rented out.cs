using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentBoat.WebSite.Areas.Customer.Models;
using RentBoat.WebSite.Areas.Customer.WorkerServices;

namespace RentBoat.WebSite.Test.Rent
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class As_the_user_I_want_to_register_a_new_boat_so_that_it_can_be_rented_out:TestBase
    {

        [TestMethod]
        public void If_the_creation_is_successful_I_get_a_boat_number_back()
        {
            WorkerService.Register(new RegisterNewBoatInputModel()
            {
                BoatName = "Boat 1",
                HourlyRate = 10
            }).BoatNumber.Should().BeGreaterThan(0);
            
        }

        [TestMethod]
        public void if_there_is_a_failure_I_get_informed_of_the_reason()
        {
            WorkerService.Invoking(x => x.Register(new RegisterNewBoatInputModel()
            {
                HourlyRate = -1
            })).ShouldThrow<Exception>();
        }
    }
}

