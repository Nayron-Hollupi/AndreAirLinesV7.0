using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreAirlinesDomain.Model
{
    public class Login
    {
        #region Properties
    
        public string UserName{ get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        #endregion
    }
}
