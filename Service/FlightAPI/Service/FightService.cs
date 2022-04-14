using System.Collections.Generic;

using FlightsAPI.Utils;
using System;
using MongoDB.Driver;
using AndreAirlinesDomain.Model;

namespace FlightsAPI.Service
{
    public class FightService
    {
        private readonly IMongoCollection<Flights> _fight;

        public FightService(IFightUtilsDatabaseSettings settings)
        {
            var figh = new MongoClient(settings.ConnectionString);
            var database = figh.GetDatabase(settings.DatabaseName);
            _fight = database.GetCollection<Flights>(settings.FightCollectionName);
        }

        public List<Flights> Get() =>
       _fight.Find(fight => true).ToList();
        public Flights Get(string id) =>
            _fight.Find<Flights>(fight => fight.Id == id).FirstOrDefault();

        public Flights GetBooking(string destination , string origin) =>
           _fight.Find<Flights>(fight => fight.Destination.CodeIATA == destination && fight.Origin.CodeIATA == origin).FirstOrDefault();
      

        public Flights Create(Flights fight)
        {


            if (fight.Destination.CodeIATA != fight.Origin.CodeIATA)
            {
                _fight.InsertOne(fight);
            }
            else
            {
                return Conflict("Origem e Destino não podem ser iguais");
            }
           
            return fight;
        }

        private Flights Conflict(string v)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Flights fightIn) =>
            _fight.ReplaceOne(fight => fight.Id == id, fightIn);

        public void Remove(Flights fightIn) =>
            _fight.DeleteOne(fight => fight.Id == fightIn.Id);

        public void Remove(string id) =>
           _fight.DeleteOne(fight => fight.Id == id);
    }
}
