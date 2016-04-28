using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentBoat.QueryStack.Model;

namespace RentBoat.QueryStack
{
    public interface IQueryRepository
    {
        IQueryable<Boat> GetBoats();
        IQueryable<Rent> GetRents();
    }
}
