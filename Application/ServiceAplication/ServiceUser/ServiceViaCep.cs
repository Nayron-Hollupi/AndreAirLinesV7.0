using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AndreAirlinesDomain.Model;
using Newtonsoft.Json;

namespace ServiceAplication.ServiceUser
{
    public class ServiceViaCep
    {
        static readonly HttpClient endereco = new HttpClient();



        public static async Task<Address> CorreioApi(string cep)
        {

            try
            {
                HttpResponseMessage response = await ServiceViaCep.endereco.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                response.EnsureSuccessStatusCode();
                string jsonendereco = await response.Content.ReadAsStringAsync();
                var endereco = JsonConvert.DeserializeObject<Address>(jsonendereco);


                return endereco;

            }
            catch (HttpRequestException)
            {
                return null;
                //throw;

            }
        }
    }
}
