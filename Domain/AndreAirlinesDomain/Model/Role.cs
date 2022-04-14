using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreAirlinesDomain.Model
{
   public class Role 
    {
        #region Properties
    
        public string Description { get; set; }
        public  Access Access  { get; set; }
        #endregion
    }
}
