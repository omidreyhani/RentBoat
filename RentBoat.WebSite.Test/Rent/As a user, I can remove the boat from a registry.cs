using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentBoat.WebSite.Areas.Customer.Models;
using RentBoat.WebSite.Areas.Customer.WorkerServices;

namespace RentBoat.WebSite.Test.Rent
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class As_a_user__I_can_remove_the_boat_from_a_registry : TestBase
    {
        [TestMethod]
        public void  If_unsuccessful_I_get_informed_of_the_reason()
        {
            WorkerService.Invoking(x => x.RemoveFromRegistery(new RemoveBoatInputModel()
            {
                BoatNumber = -1,
            })).ShouldThrow<Exception>();
        }


    }
}
