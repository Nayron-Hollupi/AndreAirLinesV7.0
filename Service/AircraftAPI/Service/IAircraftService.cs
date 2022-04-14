using System.Collections.Generic;
using AndreAirlinesDomain.Model;

namespace AircraftAPI.Service
{
    public interface IAircraftService
    {
        List<Aircraft> Get();

        Aircraft Get(string id);
        Aircraft Create(Aircraft aircraft);
        void Update(string id, Aircraft aircraftIn);
        void Remove(Aircraft aircraftIn);
        void Remove(string id);
    }
}
