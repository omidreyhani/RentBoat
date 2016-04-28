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

        public IQueryable<Boat> GetAllBoats()
        {
            using (var rentBoatContext = new RentBoatContext())
            {
                return rentBoatContext.Boats;
            };
        }


        public void RemoveBoatById(int boatId)
        {
            throw new NotImplementedException();
        }

        public void Update(Boat boat)
        {
            throw new NotImplementedException();
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
    }
}