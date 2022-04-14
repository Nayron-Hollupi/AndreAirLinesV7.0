using System.Collections.Generic;
using AndreAirlinesDomain.Model;

namespace AirportDapper.Repository
{
    public interface IAirportDataRepository
    {
        bool Add(AirportData airportData);

        List<AirportData> GetAll();
    }
}
