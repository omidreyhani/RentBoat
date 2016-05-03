namespace RentBoat.CommandStack
{
    public interface ICommandRentBoatContextDatabaseInitializer
    {
        void Initialize();
    }

    public class CommandRentBoatContextDatabaseInitializer : ICommandRentBoatContextDatabaseInitializer
    {
        public void Initialize()
        {
            using (RentBoatContext rentBoatContext = new RentBoatContext())
            {
                rentBoatContext.Database.Delete();
                rentBoatContext.Database.Initialize(true);
            }
        }
    }
}
