namespace LogAPI.Utils
{
    public interface ILogDataBaseSettings
    {
        string LogCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
