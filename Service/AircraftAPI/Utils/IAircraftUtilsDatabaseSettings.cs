namespace AircraftAPI.Utils
{
    public interface IAircraftUtilsDatabaseSettings
    {
         string AircraftCollectionName { get; set; }
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }

    }
}