using System;
using System.ComponentModel.DataAnnotations;
using AndreAirlinesDomain.Model.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace AndreAirlinesDomain.Model
{
    public class PriceBase : Entity
    {
        #region Properties

        public virtual Airport Origin { get; set; }  
        public  virtual Airport Destination { get; set; }     
        public double Value { get; set; }
        public DateTime InclusionDate {get; set;}
        #endregion
    }
}
