using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentBoat.CommandStack.Model;

namespace RentBoat.CommandStack
{
    public class RentBoatContext: DbContext 
    {
        public RentBoatContext():base("r7")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RentBoatContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(entity=> entity.ToTable(string.Format("{0}_{1}","RentBoat",entity.ClrType.Name)));
        }

        public DbSet<Boat> Boats { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}
