namespace BookingAPI.Utils
{
    public interface IBookingUtilsDatabaseSettings
    {
        string BookingCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
