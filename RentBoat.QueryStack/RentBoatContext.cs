using System.Data.Entity;
using RentBoat.QueryStack.Model;

namespace RentBoat.QueryStack
{
    public class RentBoatContext: DbContext 
    {
        public RentBoatContext():base("r4")
        {
            
        }
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(entity=> entity.ToTable(string.Format("{0}_{1}","RentBoat",entity.ClrType.Name)));
        }

        public DbSet<Boat> Boats { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}
