namespace AirportAPI.Utils
{
    public interface IAirportUtilsDatabaseSettings
    {
        string AirportCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
