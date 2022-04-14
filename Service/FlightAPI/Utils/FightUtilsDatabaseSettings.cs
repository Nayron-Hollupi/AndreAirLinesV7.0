namespace FlightsAPI.Utils
{
    public class FightUtilsDatabaseSettings :IFightUtilsDatabaseSettings
    {
        public string FightCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
