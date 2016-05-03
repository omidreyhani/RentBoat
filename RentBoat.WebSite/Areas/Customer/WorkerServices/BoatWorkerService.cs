using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RentBoat.CommandStack;
using RentBoat.CommandStack.Model;
using RentBoat.QueryStack;
using RentBoat.WebSite.Areas.Customer.Models;

namespace RentBoat.WebSite.Areas.Customer.WorkerServices
{
    public class BoatWorkerService
    {
        private readonly IRepository _repository;
        //readonly IQueryRepository _queryRepository;

        public BoatWorkerService(IRepository repository, IQueryRepository queryRepository)
        {
            _repository = repository;
            //_queryRepository = queryRepository;
        }


        public RegisterNewBoatViewModel Register(RegisterNewBoatInputModel registerNewBoatInputModel)
        {
            var boat = new Boat()
            {
                BoatName = registerNewBoatInputModel.BoatName,
                HourlyRate = registerNewBoatInputModel.HourlyRate
            };

            _repository.Add(boat);

            return new RegisterNewBoatViewModel()
            {
                BoatNumber = boat.Id
            };

        }

        public RentOutViewModel RequestRentingOut(RentOutInputModel rentOutInputModel)
        {
            var boat = _repository.GetAllBoats().FirstOrDefault(x => x.Id == rentOutInputModel.BoatNumber);

            if (boat == null)
                throw new Exception("Boat is not found");

            var rent = _repository.GetAllRents().FirstOrDefault(x => x.StartTime != null && x.EndTime == null && x.Boat.Id == rentOutInputModel.BoatNumber);

            if (rent != null)
                throw new Exception("Boat is already rented");

            var update = new Rent()
            {
                CustomerName = rentOutInputModel.CustomerName,
                StartTime = DateTime.Now,
                EndTime = null,
                Boat = _repository.GetBoatById(rentOutInputModel.BoatNumber)
            };
            _repository.Add(update);

            return new RentOutViewModel()
            {

            };

        }

        public ReturnBoatViewModel MarkAsRenturned(ReturnBoatInputModel rentOutInputModel)
        {
            var rent = _repository.GetAllBoats().Include("Rents").First(x => x.Id == rentOutInputModel.BoatNumber).Rents.FirstOrDefault();

            if (rent == null)
            {
                throw new Exception("Can not find the rent record.");
            }


            rent.EndTime = DateTime.Now;

            _repository.MarkAsRenturned(rentOutInputModel.BoatNumber, rent.EndTime.Value);

            if (rent.StartTime == null || rent.EndTime == null) throw new Exception("Cloun't mark as rented");

            TimeSpan ts = rent.EndTime.Value - rent.StartTime.Value;


            return new ReturnBoatViewModel()
            {
                RentTime = ts,
                Price = decimal.Round(ts.Seconds* rent.Boat.HourlyRate/ 60 /60,2)
            };
        }

        public RemoveBoatViewModel RemoveFromRegistery(RemoveBoatInputModel removeBoatInputModel)
        {
            _repository.RemoveBoatById(removeBoatInputModel.BoatNumber);
            return new RemoveBoatViewModel();

        }

        public IEnumerable<BoatViewModel> Index()
        {
            return _repository.GetAllBoats().Select(x => new BoatViewModel()
            {
                BoatName = x.BoatName,
                BoatNumber = x.Id,
                //CustomerName = x.,
                HourlyRate = x.HourlyRate
            });
        }
    }
}