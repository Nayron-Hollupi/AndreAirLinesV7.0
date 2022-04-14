using System.Collections.Generic;
using System.Threading.Tasks;
using AeroportoAPI.Service;
using AndreAirlinesDomain.Model;
using LogRabbitService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AirportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly AirportService _airportService;


        public AirportController(AirportService aiportService)
        {
            _airportService = aiportService;
        }

        [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<List<Airport>> Get() =>
            _airportService.Get();


        [HttpGet("{id:length(24)}", Name = "GetAirport")]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<Airport> Get(string id)
        {
            var airport = _airportService.Get(id);

            if (airport == null)
            {
                return NotFound();
            }

            return airport;
        }


        [HttpGet("{CodeIATA}", Name = "GetCodeIATA")]
        [AllowAnonymous]
        public ActionResult<Airport> GetAirportCodeIATA(string CodeIATA)
        {
            var airport = _airportService.GetCodeIATA(CodeIATA);

            if (airport == null)
                return NotFound("Aiport no Exist");

            return airport;
        }
    

        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<Airport>> Create(Airport airport)
        {
            var code = _airportService.VerifyCodigoIATA(airport.CodeIATA, airport.AddressAirport.CEP);
            
            

            if (code == null )
            {

                var airportJson = JsonConvert.SerializeObject(airport);
                var lograbbit = new Log(airport.LoginUser, null, airportJson, "Create");

                SenderMongoServerService.LoginRabbit(lograbbit);

                await  _airportService.Create(airport);
            }
            else
            {
                return Conflict("Aeroporto  já cadastrado!!");
            }
           

            return CreatedAtRoute("GetAirport", new { Id = airport.Id.ToString() }, airport);
        }

        [HttpPut("{id:length(24)}")]
        [Authorize(Roles = "manager")]
        public IActionResult Update(string id, Airport airportIn)
        {
            var airport = _airportService.Get(id);

            if (airport == null)
            {
                return NotFound();
            }

            var oldairport = JsonConvert.SerializeObject(airport);
            var airportJson = JsonConvert.SerializeObject(airportIn);
            var lograbbit = new Log(airport.LoginUser, oldairport, airportJson, "Update");

            SenderMongoServerService.LoginRabbit(lograbbit);
            _airportService.Update(id, airportIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = "manager")]
        public IActionResult Delete(string id)
        {
            var airport = _airportService.Get(id);

            if (airport == null)
            {
                return NotFound();
            }

            var airportJson = JsonConvert.SerializeObject(airport);
            var lograbbit = new Log(airport.LoginUser, null, airportJson, "Delete");

            SenderMongoServerService.LoginRabbit(lograbbit);

            _airportService.Remove(airport.Id);

            return NoContent();
        }
    }
}
