namespace LogRabbitMQA.Utils
{
    public interface ILogMQADataBaseSettings
    {
        string LogMQACollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
