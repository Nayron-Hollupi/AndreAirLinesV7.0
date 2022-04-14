using System;
using AndreAirlinesDomain.Model.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace AndreAirlinesDomain.Model
{
    public class Flights : Entity
    {
        #region Properties

        public Airport Destination { get; set; }
        public Airport Origin { get; set; }
        public Aircraft Aircraft { get; set; }
        public DateTime BoardingTime { get; set; }
        public DateTime LandingTime { get; set; }
        #endregion
    }
}
