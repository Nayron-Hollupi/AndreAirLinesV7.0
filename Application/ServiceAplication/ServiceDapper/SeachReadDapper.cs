using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreAirlinesDomain.Model;

namespace ServiceAplication.ServiceDapper
{
    public class SeachReadDapper
    {
        static void Main(string[] args)
        {
          /*  StreamReader readerAirport = new StreamReader(@"C:\Users\Nayron\OneDrive\Área de Trabalho\json\Dados.csv");

            string line;
            do
            {
                line = readerAirport.ReadLine();
                if (line != null)
                {
                    var values = line.Split(';');
                    AirportData airportData = new AirportData(values[0], values[1], values[2], values[3]);
                  new AirportDataService().Add(airportData);
                }

            } while (line != null);

            foreach (var airport in new AirportDataService().GetAll())
            {
                Console.WriteLine(airport);
            }*/
        }
    }
}
