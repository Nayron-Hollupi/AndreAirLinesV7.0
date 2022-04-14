using System.Collections.Generic;
using System.Threading.Tasks;
using AirportDapper.Service;
using AndreAirlinesDomain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace AirportDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportDapperController : ControllerBase
    {
     
            private readonly AirportDataService _airportDataService;


            public AirportDapperController(AirportDataService aiportDataService)
            {
                _airportDataService = aiportDataService;
            }

            [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<List<AirportData>> Get() =>
                _airportDataService.GetAll();


            [HttpPost  ]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<AirportData>> Create(AirportData airportData)
            {
                                           
                    _airportDataService.Add(airportData);
             
                              
                return CreatedAtRoute("GetAirport", new { Id = airportData.Id }, airportData);
            }


        }
    }

