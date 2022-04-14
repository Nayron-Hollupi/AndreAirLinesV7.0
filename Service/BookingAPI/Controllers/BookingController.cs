using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookingAPI.Service;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using AndreAirlinesDomain.Model;
using ServiceAplication.ServiceFlight;
using ServiceAplication.ServicePriceBase;
using ServiceAplication.ServicePassenger;
using Newtonsoft.Json;
using LogRabbitService;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;


        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<List<Booking>> Get() =>
            _bookingService.Get();


        [HttpGet("{id:length(24)}", Name = "GetBooking")]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<Booking> Get(string id)
        {
            var booking = _bookingService.Get(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<Booking>> Create(Booking booking)
        {
            var flight = await ServiceSeachFlight.SeachFlights(booking.Flights.Destination.CodeIATA, booking.Flights.Origin.CodeIATA);
            var priceBase = await ServiceSeachPriceBase.SeachPriceBase(booking.Flights.Destination.CodeIATA, booking.Flights.Origin.CodeIATA);
            var passenger = await ServiceSeachPassenger.SeachPassenger(booking.Passenger.CodePassenger);
            var typeClass = await ServiceSeachClass.SeachTypeClass(booking.TypeClass.Description);
            
           

            if(booking.Flights != null && booking.Passenger != null && booking.TypeClass != null)
            {

                booking.Flights = flight;
                booking.Passenger = passenger;
                booking.TypeClass = typeClass;
                booking.Value = priceBase.Value + (priceBase.Value * typeClass.Value);
                booking.Value = booking.Value - (booking.Value * booking.PercentPromotion);

                var bookingJson = JsonConvert.SerializeObject(booking);
                var lograbbit = new Log(booking.LoginUser, null, bookingJson, "Create");

                SenderMongoServerService.LoginRabbit(lograbbit);


                _bookingService.Create(booking);
                return CreatedAtRoute("GetBooking", new { Id = booking. Id.ToString() }, booking);

            }
            else
            {
                return Conflict("service unavailable.");
            }

           

           
        }

        [HttpPut("{id:length(24)}")]
        [Authorize(Roles = "manager")]
        public IActionResult Update(string id, Booking bookingIn)
        {
            var booking = _bookingService.Get(id);

            if (booking == null)
            {
                return NotFound();
            }


            var oldbooking = JsonConvert.SerializeObject(booking);
            var bookingJson = JsonConvert.SerializeObject(bookingIn);
            var lograbbit = new Log(booking.LoginUser, oldbooking, bookingJson, "Update");

            SenderMongoServerService.LoginRabbit(lograbbit);

            _bookingService.Update(id, bookingIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = "manager")]
        public IActionResult Delete(string id)
        {
            var booking = _bookingService.Get(id);

            if (booking == null)
            {
                return NotFound();
            }


            var bookingJson = JsonConvert.SerializeObject(booking);
            var lograbbit = new Log(booking.LoginUser, null, bookingJson, "Delete");

            SenderMongoServerService.LoginRabbit(lograbbit);

            _bookingService.Remove(booking.Id);

            return NoContent();
        }
    }
}
