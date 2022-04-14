using System.Collections.Generic;
using AndreAirlinesDomain.Model;
using MongoDB.Driver;
using PriceBaseAPI.Utils;

namespace PriceBaseAPI.Service
{
    public class PriceBaseService
    {

        private readonly IMongoCollection<PriceBase> _priceBase;

        public PriceBaseService(IPriceBaseUtilsDatabaseSettings settings)
        {
            var price = new MongoClient(settings.ConnectionString);
            var database = price.GetDatabase(settings.DatabaseName);
            _priceBase = database.GetCollection<PriceBase>(settings.PriceBaseCollectionName);
        }

        public List<PriceBase> Get() =>
       _priceBase.Find(priceBase => true).ToList();
        public PriceBase Get(string id) =>
            _priceBase.Find<PriceBase>(priceBase => priceBase.Id == id).FirstOrDefault();


        public PriceBase GetBookingPriBase(string destination, string origin) =>
           _priceBase.Find<PriceBase>(priceBase => priceBase.Destination.CodeIATA == destination && priceBase.Origin.CodeIATA == origin).FirstOrDefault();


        public PriceBase Create(PriceBase priceBase)
        {    
            _priceBase.InsertOne(priceBase);
            return priceBase;
        }

        public void Update(string id, PriceBase priceBaseIn) =>
            _priceBase.ReplaceOne(priceBase => priceBase.Id == id, priceBaseIn);

        public void Remove(PriceBase priceBaseIn) =>
            _priceBase.DeleteOne(priceBase => priceBase.Id == priceBaseIn.Id);

        public void Remove(string id) =>
           _priceBase.DeleteOne(priceBase => priceBase.Id == id);
    }
}
