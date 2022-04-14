using System.ComponentModel.DataAnnotations;
using AndreAirlinesDomain.Model.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreAirlinesDomain.Model
{
    public class TypeClass : Entity
    {
        #region Properties
        public string Description { get; set; }
        public double Value { get; set; }
        #endregion
    }
}
