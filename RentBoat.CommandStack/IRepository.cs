using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentBoat.CommandStack.Model;

namespace RentBoat.CommandStack
{
    public interface IRepository
    {
        void Add(Boat boat);
        IQueryable<Boat> GetAllBoats();

        void RemoveBoatById(int boatId);
        void Update(Boat boat);
        void Add(Rent rent);
        Boat GetBoatById(int boatNumber);
    }
}
