using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentBoat.WebSite.Areas.Customer.Models;
using RentBoat.WebSite.Areas.Customer.WorkerServices;

namespace RentBoat.WebSite.Test.Rent
{
    [TestClass]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    // ReSharper disable once InconsistentNaming
    public class As_a_user__I_can_remove_the_boat_from_a_registry : TestBase
    {
        [TestMethod]
        public void Remove_successfully()
        {
            var boatViewModel = WorkerService.Register(new RegisterNewBoatInputModel() { BoatName = "Boat 1", HourlyRate = 3 });

            WorkerService.RemoveFromRegistery(new RemoveBoatInputModel()
            {
                BoatNumber =boatViewModel.BoatNumber
            });
        }

        [TestMethod]
        public void If_unsuccessful_I_get_informed_of_the_reason()
        {
            WorkerService.Invoking(x => x.RemoveFromRegistery(new RemoveBoatInputModel()
            {
                BoatNumber = -1,
            }))
                .ShouldThrow<DbUpdateConcurrencyException>()
                .WithMessage(
                    "Store update, insert, or delete statement affected an unexpected number of rows (0). Entities may have been modified or deleted since entities were loaded. See http://go.microsoft.com/fwlink/?LinkId=472540 for information on understanding and handling optimistic concurrency exceptions.");
        }
    }
}
