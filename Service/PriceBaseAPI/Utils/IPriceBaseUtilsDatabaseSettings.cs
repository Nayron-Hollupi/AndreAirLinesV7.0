namespace PriceBaseAPI.Utils
{
    public interface IPriceBaseUtilsDatabaseSettings
    {
        string PriceBaseCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
