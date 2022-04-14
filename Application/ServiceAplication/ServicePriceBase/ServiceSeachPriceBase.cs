using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AndreAirlinesDomain.Model;
using Newtonsoft.Json;

namespace ServiceAplication.ServicePriceBase
{
    public class ServiceSeachPriceBase
    {
        static readonly HttpClient priceBase = new HttpClient();

        public static async Task<PriceBase> SeachPriceBase(string destination, string origin)
        {
            try
            {

                HttpResponseMessage response = await priceBase.GetAsync("https://localhost:44338/api/PriceBase/" + origin + "/" + destination);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var priceBaseJson = JsonConvert.DeserializeObject<PriceBase>(responseBody);
                return priceBaseJson;
            }
            catch (Exception)
            {

                return null;
                //throw;
            }
        }
    }
}
