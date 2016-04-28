using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentBoat.QueryStack
{
    public interface IQueryRentBoatContexttDatabaseInitializer
    {
        void Initialize();
    }

    public class RentBoatContextDatabaseInitializer : IQueryRentBoatContexttDatabaseInitializer
    {
        public void Initialize()
        {
            using (RentBoatContext rentBoatContext = new RentBoatContext())
            {
               rentBoatContext.Database.Initialize(true); 
            } 
        }
    }
}
