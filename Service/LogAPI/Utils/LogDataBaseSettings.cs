namespace LogAPI.Utils
{
    public class LogDataBaseSettings : ILogDataBaseSettings
    {
        public string LogCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
