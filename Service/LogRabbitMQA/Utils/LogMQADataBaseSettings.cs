namespace LogRabbitMQA.Utils
{
    public class LogMQADataBaseSettings : ILogMQADataBaseSettings
    {
        public string LogMQACollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
