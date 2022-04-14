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
    public class ServiceSeachClass
    {
        static readonly HttpClient typeClass = new HttpClient();

        public static async Task<TypeClass> SeachTypeClass(string description)
        {
            try
            {

                HttpResponseMessage response = await typeClass.GetAsync("https://localhost:44307/api/TypeClass/" + description);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var classeJson = JsonConvert.DeserializeObject<TypeClass>(responseBody);
                return classeJson;
            }
            catch (Exception)
            {

                return null;
                //throw;
            }
        }
    }
}
