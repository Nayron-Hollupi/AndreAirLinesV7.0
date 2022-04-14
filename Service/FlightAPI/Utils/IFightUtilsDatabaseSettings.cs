namespace FlightsAPI.Utils
{
    public interface IFightUtilsDatabaseSettings
    {
        string FightCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
