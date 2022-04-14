namespace PassengerAPI.Utils
{
    public class PassengerUtilsDatabaseSettings : IPassengerUtilsDatabaseSettings
    {
        public string PassengerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}