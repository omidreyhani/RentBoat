using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentBoat.CommandStack.Model;

namespace RentBoat.CommandStack
{
    public interface IUnitOfWork : IDisposable
    {
        void Add(Boat book);
        void Save();
        IRepository Repository { get; set; }
        void Update(Boat boat);
    }
}
