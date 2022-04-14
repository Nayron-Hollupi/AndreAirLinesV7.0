using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AndreAirlinesDomain.Model;
using Newtonsoft.Json;

namespace ServiceAplication.ServiceFlight
{
    public class ServiceSeachFlight
    {
        static readonly HttpClient flight = new HttpClient();

        public static async Task<Flights> SeachFlights(string destination, string origin)
        {
            try
            {

                HttpResponseMessage response = await flight.GetAsync("https://localhost:44390/api/Fight/" + origin + "/" + destination);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var flightJson = JsonConvert.DeserializeObject<Flights>(responseBody);


                return flightJson;

            }
            catch (Exception)
            {

                return null;
                //throw;
            }
        }
    }
}
