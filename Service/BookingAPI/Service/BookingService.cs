using System.Collections.Generic;
using AndreAirlinesDomain.Model;
using BookingAPI.Utils;
using MongoDB.Driver;

namespace BookingAPI.Service
{
    public class BookingService
    {

        private readonly IMongoCollection<Booking> booking;

        public BookingService(IBookingUtilsDatabaseSettings settings)
        {
            var bookin = new MongoClient(settings.ConnectionString);
            var database = bookin.GetDatabase(settings.DatabaseName);
            booking = database.GetCollection<Booking>(settings.BookingCollectionName);
        }

        public List<Booking> Get() =>
       booking.Find(booking => true).ToList();
        public Booking Get(string id) =>
            booking.Find<Booking>(booking => booking.Id == id).FirstOrDefault();

        public Booking Create(Booking booking)
        {
            this.booking.InsertOne(booking);
            return booking;
        }

        public void Update(string id, Booking bookingIn) =>
            booking.ReplaceOne(booking => booking.Id == id, bookingIn);

        public void Remove(Booking bookingIn) =>
            booking.DeleteOne(booking => booking.Id == bookingIn.Id);

        public void Remove(string id) =>
           booking.DeleteOne(booking => booking.Id == id);
    }
}
