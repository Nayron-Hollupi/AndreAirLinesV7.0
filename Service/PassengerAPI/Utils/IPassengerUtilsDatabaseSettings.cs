namespace PassengerAPI.Utils
{
    public interface IPassengerUtilsDatabaseSettings
    {
         string PassengerCollectionName { get; set; }
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }

    }
}