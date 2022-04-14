using System.Collections.Generic;
using System.Data.SqlClient;
using AirportDapper.Config;
using AndreAirlinesDomain.Model;
using Dapper;

namespace AirportDapper.Repository
{
    public class AirportDataRepository : IAirportDataRepository
    {
        private string _connection;

        public AirportDataRepository()
        {
            _connection = DataBaseConfiguration.Get();
        }

        public bool Add(AirportData airportData)
        {
            bool status = false;

            using(var db_airport = new SqlConnection(_connection))
            {
                db_airport.Open();
                db_airport.Execute(AirportData.INSERT, airportData);
                status = true;
            }
            return status;
        }

        public List<AirportData> GetAll()
        {
            using(var db_airport = new SqlConnection(_connection))
            {
                db_airport.Open();
                var airport = db_airport.Query<AirportData>(AirportData.GETALL);
                return (List<AirportData>)airport;
            }
        }


    }
}
