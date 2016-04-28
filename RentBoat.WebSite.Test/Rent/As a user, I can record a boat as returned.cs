using System;
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

        [TestMethod]
        public void  If_the_boat_is_currently_rented_out_it_cannot_be_rented_out()
        {
            WorkerService.Invoking(x => x.MarkAsRenturned(new ReturnBoatInputModel()
            {
                BoatNumber = 1,
            })).ShouldThrow<Exception>().WithMessage("Currently rented out");
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
