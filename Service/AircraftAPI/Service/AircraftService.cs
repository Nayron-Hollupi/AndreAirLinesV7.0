using System.Collections.Generic;

using System.Threading.Tasks;
using System;
using AircraftAPI.Utils;
using AndreAirlinesDomain.Model;
using MongoDB.Driver;

namespace AircraftAPI.Service
{
    public class AircraftService : IAircraftService
    {

        private readonly IMongoCollection<Aircraft> _aircraft;

        public AircraftService(IAircraftUtilsDatabaseSettings settings)
        {

                var clientmongo = new MongoClient(settings.ConnectionString);
                var database = clientmongo.GetDatabase(settings.DatabaseName);
            _aircraft = database.GetCollection<Aircraft>(settings.AircraftCollectionName);
          
        }
       


        public List<Aircraft> Get() =>
       _aircraft.Find(aircraft => true).ToList();

        public Aircraft Get(string id) =>
            _aircraft.Find<Aircraft>(aircraft => aircraft.Id == id).FirstOrDefault();

        public Aircraft CheckRegistro(string Registry) =>
            _aircraft.Find<Aircraft>(aircraft => aircraft.Registry == Registry).FirstOrDefault();

        public Aircraft GetRegistry(string Registry) =>
       _aircraft.Find<Aircraft>(aircraft => aircraft.Registry == Registry).FirstOrDefault();

        public Aircraft Create(Aircraft aircraft)
        {
            _aircraft.InsertOne(aircraft);
            return aircraft;
        }

        public void Update(string id, Aircraft aircraftIn) =>
            _aircraft.ReplaceOne(aircraft => aircraft.Id == id, aircraftIn);

        public void Remove(Aircraft aircraftIn) =>
            _aircraft.DeleteOne(aircraft => aircraft.Id == aircraftIn.Id);

        public void Remove(string id) =>
           _aircraft.DeleteOne(aircraft => aircraft.Id == id);
    }
}

