using System;
using System.Web.Mvc;
using RentBoat.WebSite.Areas.Customer.Models;
using RentBoat.WebSite.Areas.Customer.WorkerServices;
using ModelBinderAttribute = System.Web.Http.ModelBinding.ModelBinderAttribute;

namespace RentBoat.WebSite.Areas.Customer.Controllers
{
    public class BoatController : Controller
    {
        public BoatWorkerService WorkerService { get; private set; }

        public BoatController(BoatWorkerService boatWorkerService)
        {
            if (boatWorkerService == null)
                throw new ArgumentNullException("workerService");

            WorkerService = boatWorkerService;
        }

        public ActionResult Index()
        {
            return View(WorkerService.Index());
        }

        // GET: Customer/Boat
        public ActionResult Register()
        {
            return View(new RegisterNewBoatInputModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterNewBoatInputModel registerNewBoatInputModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return View("RegisterIsSuccesful", WorkerService.Register(registerNewBoatInputModel));
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("", exception.Message);
                }
            }

            return View(registerNewBoatInputModel);
        }

        // GET: Customer/Boat
        public ActionResult RequestRentingOut()
        {
            return View(new RentOutInputModel());
        }


        [HttpPost]
        public ActionResult RequestRentingOut(RentOutInputModel rentOutInputModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return View("RentOutWasSuccesful", WorkerService.RequestRentingOut(rentOutInputModel));
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("", exception.Message);
                }
            }

            return View();
        }

        // GET: Customer/Boat
        public ActionResult MarkAsRenturned()
        {
            return View(new ReturnBoatInputModel());
        }


        [HttpPost]
        public ActionResult MarkAsRenturned(ReturnBoatInputModel returnBoatInputModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return View("ReturnBoatWasSuccessful", WorkerService.MarkAsRenturned(returnBoatInputModel));
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("", exception.Message);
                }
            }

            return View();
        }

        // GET: Customer/Boat
        public ActionResult RemoveFromRegistery()
        {
            return View(new RemoveBoatInputModel());
        }


        [HttpPost]
        public ActionResult RemoveFromRegistery(RemoveBoatInputModel removeBoatInputModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return View("RemoveFromRegisteryWasSuccessful", WorkerService.RemoveFromRegistery(removeBoatInputModel));
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("", exception.Message);
                }
            }

            return View();
        }



    }
}