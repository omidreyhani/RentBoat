using System;
using System.Linq;
using RentBoat.CommandStack.Model;

namespace RentBoat.CommandStack
{
    public interface IRepository
    {
        void Add(Boat boat);
        IQueryable<Boat> GetAllBoats();
        IQueryable<Rent> GetAllRents();

        void RemoveBoatById(int boatId);
        void Add(Rent rent);
        void MarkAsRenturned(int boatNumber, DateTime endTime);
    }
}
