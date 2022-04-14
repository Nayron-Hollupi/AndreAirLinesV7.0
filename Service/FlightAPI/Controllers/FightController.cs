using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FlightsAPI.Service;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using AndreAirlinesDomain.Model;
using ServiceAplication.ServiceAirport;
using ServiceAplication.ServiceAircraft;
using Newtonsoft.Json;
using LogRabbitService;

namespace FlightsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightController : ControllerBase
    {
        private readonly FightService _flightService;


        public FightController(FightService fightService)
        {
            _flightService = fightService;
        }

        [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<List<Flights>> Get() =>
            _flightService.Get();


        [HttpGet("{id:length(24)}", Name = "GetFlight")]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<Flights> Get(string id)
        {
            var flight = _flightService.Get(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        [HttpGet("{Origin}/{Destination}" , Name = "GetFlightBooking")]
        public async Task<ActionResult<Flights>> GetBookingFlights(string destination, string origin)
        {
            var flight = _flightService.GetBooking(destination, origin);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }
       
        [HttpPost]
        [Authorize(Roles = "employee,manager")]
        public  async Task<ActionResult<Flights>> Create(Flights flight)
        {
            var destination =  await ServiceSeachAirport.SeachAirport(flight.Destination.CodeIATA);
            var origin = await ServiceSeachAirport.SeachAirport(flight.Origin.CodeIATA);
            var aircraft = await ServiceSeachAircraft.SeachAircraft(flight.Aircraft.Registry);
          

            flight.Destination = destination;
            flight.Origin = origin;
            flight.Aircraft = aircraft;
;

            if (origin != null && destination != null && aircraft != null)
            {
                if (origin.CodeIATA != destination.CodeIATA)
                {
                    flight.Destination = destination;
                    flight.Origin = origin;
                    flight.Aircraft = aircraft;



                    var originJson = JsonConvert.SerializeObject(origin);
                    var lograbbit = new Log(origin.LoginUser, null, originJson, "Create");

                    SenderMongoServerService.LoginRabbit(lograbbit);


                    _flightService.Create(flight);
                }
                else
                {
                    return Conflict("A origem e destino não pode ser iguais.");
                }
            }
            else
            {
                return Conflict("Serviço indisponivel no momento.");
            }

            return CreatedAtRoute("GetFight", new { Id = flight.Id.ToString() }, flight);
        }

        [HttpPut("{id:length(24)}")]
        [Authorize(Roles = "employee,manager")]
        public IActionResult Update(string id, Flights flightIn)
        {
            var flight = _flightService.Get(id);

            if (flight == null)
            {
                return NotFound();
            }

            var oldflight = JsonConvert.SerializeObject(flight);
            var flightJson = JsonConvert.SerializeObject(flightIn);
            var lograbbit = new Log(flight.LoginUser, oldflight, flightJson, "Update");

            SenderMongoServerService.LoginRabbit(lograbbit);


            _flightService.Update(id, flightIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = "employee,manager")]
        public IActionResult Delete(string id)
        {
            var flight = _flightService.Get(id);

            if (flight == null)
            {
                return NotFound();
            }



            var flightJson = JsonConvert.SerializeObject(flight);
            var lograbbit = new Log(flight.LoginUser, null, flightJson, "Delete");

            SenderMongoServerService.LoginRabbit(lograbbit);
            _flightService.Remove(flight.Id);

            return NoContent();
        }
    }
}
