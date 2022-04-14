using System;
using AndreAirlinesDomain.Model.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace AndreAirlinesDomain.Model
{
    public class Booking : Entity
     {
        #region Properties
        
        public Passenger Passenger { get; set; }
        public  virtual Flights Flights { get; set; }  
        public virtual TypeClass TypeClass { get; set; }
      
        public DateTime RegisterDate { get; set; }
        public double Value { get; set; }
        public double PercentPromotion { get; set; }
        #endregion
    }
}
