
using AndreAirlinesDomain.Model.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreAirlinesDomain.Model
{
    public class Airport : Entity
    {
        #region Properties
     
        public string CodeIATA { get; set; }
        public string Name { get; set; }
        public AddressAirport AddressAirport { get; set; }

        #endregion  


    }

  
}
