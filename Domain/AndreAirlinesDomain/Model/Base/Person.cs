using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreAirlinesDomain.Model.Base
{
   public abstract class Person

    {

        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public  Address Address { get; set; }


        #endregion
    }
}
