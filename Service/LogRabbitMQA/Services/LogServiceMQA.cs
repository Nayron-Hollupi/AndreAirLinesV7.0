using System.Collections.Generic;
using AndreAirlinesDomain.Model;
using LogRabbitMQA.Utils;
using MongoDB.Driver;

namespace LogRabbitMQA.Services
{
    public class LogServiceMQA
    {
        private readonly IMongoCollection<Log> _logs;

        public LogServiceMQA(ILogMQADataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _logs = database.GetCollection<Log>(settings.LogMQACollectionName);
        }


        public List<Log> Get() =>
            _logs.Find(log => true).ToList();

        public Log Get(string id) =>
            _logs.Find<Log>(log => log.Id == id).FirstOrDefault();

        public Log Create(Log log)
        {
            _logs.InsertOne(log);
            return log;
        }

        public void Update(string id, Log logIn) =>
            _logs.ReplaceOne(log => log.Id == id, logIn);

        public void Remove(Log logIn) =>
            _logs.DeleteOne(log => log.Id == logIn.Id);

        public void Remove(string id) =>
            _logs.DeleteOne(log => log.Id == id);
    }
}

