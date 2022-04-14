using System.Collections.Generic;
using AirportDapper.Repository;
using AndreAirlinesDomain.Model;

namespace AirportDapper.Service
{
    public class AirportDataService
    {
        private IAirportDataRepository _airportDataRepository;

        public AirportDataService()
        {
            _airportDataRepository = new AirportDataRepository();
        }


        public bool Add(AirportData airportData)
        {
            return _airportDataRepository.Add(airportData);
        }

        public List<AirportData> GetAll()
        {
            return _airportDataRepository.GetAll();
        }
    }
}
