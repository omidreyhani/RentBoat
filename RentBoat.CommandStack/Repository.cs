using System;
using System.Linq;
using RentBoat.CommandStack.Model;

namespace RentBoat.CommandStack
{
    public class Repository : IRepository
    {
        public void Add(Boat boat)
        {
            using (var rentBoatContext = new RentBoatContext())
            {
                rentBoatContext.Boats.Add(boat);
                rentBoatContext.SaveChanges();
            }
        }

        readonly RentBoatContext _rentBoatContext=new RentBoatContext();
        public IQueryable<Boat> GetAllBoats()
        {
                return _rentBoatContext.Boats;
        }

        public IQueryable<Rent> GetAllRents()
        {
                return _rentBoatContext.Rents;
        }


        public void RemoveBoatById(int boatId)
        {
            using (var rentBoatContext = new RentBoatContext())
            {
                Boat boat =new Boat(){ Id = boatId};
                rentBoatContext.Boats.Attach(boat);
                rentBoatContext.Boats.Remove(boat);
                rentBoatContext.SaveChanges();
            }; 
        }

        public void Add(Rent rent)
        {
            using (var rentBoatContext = new RentBoatContext())
            {
                rentBoatContext.Rents.Add(rent);
                rentBoatContext.SaveChanges();
            };
        }

        public Boat GetBoatById(int boatNumber)
        {
            using (var rentBoatContext = new RentBoatContext())
            {
                return rentBoatContext.Boats.FirstOrDefault(x => x.Id == boatNumber);
            }; 
        }

        public void MarkAsRenturned(int boatNumber, DateTime endTime)
        {
            using (var rentBoatContext = new RentBoatContext())
            {
                var rent = rentBoatContext.Rents.FirstOrDefault(x => x.Boat.Id == boatNumber && x.EndTime == null);
                rent.EndTime = endTime;
                rentBoatContext.SaveChanges();
            };  
        }
    }
}