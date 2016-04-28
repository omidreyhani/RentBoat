using System;
using System.Collections;
using System.Collections.Generic;
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
        readonly IQueryRepository _queryRepository;

        public BoatWorkerService(IRepository repository, IQueryRepository queryRepository)
        {
            _repository = repository;
            _queryRepository = queryRepository;
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
            var boat = _queryRepository.GetBoats().FirstOrDefault(x => x.Id == rentOutInputModel.BoatNumber );
           
            if(boat==null)
                throw new Exception("Boat is not found");

            var rent = _queryRepository.GetRents().FirstOrDefault(x => x.StartTime != null && x.EndTime ==null);

            if(rent!=null)
                throw new Exception("Boat is already rented");

            var update = new Rent()
            {
                CustomerName =rentOutInputModel.CustomerName,
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
            //var boat = _queryRepository.GetBoats().FirstOrDefault(x => x.Id == rentOutInputModel.BoatNumber);

            //if (boat == null)
            //    throw new Exception("Boat is not found");
            //if (!string.IsNullOrEmpty(boat.CustomerName))
            //    throw new Exception("Boat is already rented");

            //var update = new Boat()
            //{
            //    CustomerName = ""
            //};
            //_repository.Update(update);

            return new ReturnBoatViewModel()
            {
                
            };
        }

        public RemoveBoatViewModel RemoveFromRegistery(RemoveBoatInputModel removeBoatInputModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BoatViewModel> Index()
        {
            return _queryRepository.GetBoats().Select(x=>new BoatViewModel()
            {
                BoatName = x.BoatName,
                BoatNumber = x.Id,
                CustomerName = x.CustomerName,
                HourlyRate = x.HourlyRate
            });
        }
    }
}