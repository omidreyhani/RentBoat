using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentBoat.QueryStack.Model;

namespace RentBoat.QueryStack
{
    public class QueryRepository:IQueryRepository
    {
        RentBoatContext _rentBoatContext = new RentBoatContext();

        public IQueryable<Boat> GetBoats()
        {
            return _rentBoatContext.Boats;
        }

        public IQueryable<Rent> GetRents()
        {
            return _rentBoatContext.Rents; ;
        }
    }
}
