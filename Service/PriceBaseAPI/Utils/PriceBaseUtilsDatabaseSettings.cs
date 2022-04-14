namespace PriceBaseAPI.Utils
{
    public class PriceBaseUtilsDatabaseSettings : IPriceBaseUtilsDatabaseSettings
    {
        public string PriceBaseCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
