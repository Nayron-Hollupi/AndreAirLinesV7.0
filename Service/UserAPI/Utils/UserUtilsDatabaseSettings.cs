namespace UserAPI.Utils
{
    public class UserUtilsDatabaseSettings : IUserUtilsDatabaseSettings
    {
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}