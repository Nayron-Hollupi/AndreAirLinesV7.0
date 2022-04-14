namespace BookingAPI.Utils
{
    public class BookingUtilsDatabaseSettings : IBookingUtilsDatabaseSettings
    {

        public string BookingCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
