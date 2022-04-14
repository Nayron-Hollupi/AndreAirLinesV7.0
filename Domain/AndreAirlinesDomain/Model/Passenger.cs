using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreAirlinesDomain.Model.Base;

namespace AndreAirlinesDomain.Model
{
    public class Passenger : Person
    {
        public string CodePassenger { get; set; }
        public string LoginUser { get; set; }
    }
}
