using AndreAirlinesDomain.Model.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreAirlinesDomain.Model
{
    public class Aircraft : Entity
    {
        #region Properties
     
        public string Registry { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        #endregion
    }

}
