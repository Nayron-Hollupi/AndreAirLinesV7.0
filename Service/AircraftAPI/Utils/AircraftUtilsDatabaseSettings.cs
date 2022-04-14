namespace AircraftAPI.Utils
{
    public class AircraftUtilsDatabaseSettings : IAircraftUtilsDatabaseSettings
    {
        public string AircraftCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}