namespace AirportAPI.Utils
{
    public class AirportUtilsDatabaseSettings : IAirportUtilsDatabaseSettings
    {
        public string AirportCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
