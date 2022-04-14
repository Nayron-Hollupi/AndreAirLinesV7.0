using System.Collections.Generic;
using System.Threading.Tasks;
using AirportAPI.Utils;
using AndreAirlinesDomain.Model;
using MongoDB.Driver;

namespace AeroportoAPI.Service
{
    public class AirportService
    {

        private readonly IMongoCollection<Airport> _airport;

        public AirportService(IAirportUtilsDatabaseSettings settings)
        {
            var aeropor = new MongoClient(settings.ConnectionString);
            var database = aeropor.GetDatabase(settings.DatabaseName);
            _airport = database.GetCollection<Airport>(settings.AirportCollectionName);
        }
        public List<Airport> Get() =>
     _airport.Find(aeroporto => true).ToList();
        public Airport Get(string id) =>
            _airport.Find<Airport>(airport => airport.Id == id).FirstOrDefault();

        public Airport GetCodeIATA(string CodeIATA) =>
           _airport.Find<Airport>(airport => airport.CodeIATA == CodeIATA).FirstOrDefault();
        public Airport VerifyCodigoIATA(string CodeIATA, string CEP) =>
            _airport.Find<Airport>(airport => airport.CodeIATA.ToUpper() == CodeIATA.ToUpper() || airport.AddressAirport.CEP == CEP).FirstOrDefault();

  

        public async Task<Airport> Create(Airport airport)
        {
          
            _airport.InsertOne(airport);
            return airport;
        }

        public void Update(string id, Airport airportIn) =>
            _airport.ReplaceOne(airport => airport.Id == id, airportIn);

        public void Remove(Airport airportIn) =>
            _airport.DeleteOne(airport => airport.Id == airportIn.Id);

        public void Remove(string id) =>
           _airport.DeleteOne(airport => airport.Id == id);
    }
}
