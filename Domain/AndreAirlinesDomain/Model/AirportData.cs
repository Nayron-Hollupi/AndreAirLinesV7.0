using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreAirlinesDomain.Model
{
    public class AirportData
    {
        #region Constan
        public readonly static string INSERT = "INSERT INTO Airport(City, Country, Code, Continent) VALUES (@City, @Country, @Code, @Continent)";

        public readonly static string GETALL = "SELECT Id, City, Country, Code, Continent FROM Airport";

        #endregion
        #region Properties
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }
        public string Continent { get; set; }

        public AirportData(string city, string country, string code, string continent)
        {
            City = city;
            Country = country;
            Code = code;
            Continent = continent;
        }

        public AirportData()
        {
        }
        #endregion



        #region Method

        public override string ToString()
        {
            return "\nId:" + Id +
                    "\nCity :" + City +
                    "\nCountry :" + Country +
                    "\nCode :" + Code +
                    "\nContinent : " + Continent;



        }
        #endregion
    }
}
