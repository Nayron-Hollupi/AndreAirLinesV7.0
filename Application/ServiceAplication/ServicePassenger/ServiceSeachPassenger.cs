using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AndreAirlinesDomain.Model;
using Newtonsoft.Json;

namespace ServiceAplication.ServicePassenger
{
    public class ServiceSeachPassenger
    {
        static readonly HttpClient user = new HttpClient();

        public static async Task<Passenger> SeachPassenger(string CodePassenger)
        {
            try
            {

                HttpResponseMessage response = await user.GetAsync("https://localhost:44369/api/Passenger/" + CodePassenger);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var passengerJson = JsonConvert.DeserializeObject<Passenger>(responseBody);
                return passengerJson;
            }
            catch (Exception)
            {

                return null;
                //throw;
            }
        }
    }
}
