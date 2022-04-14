namespace UserAPI.Utils
{
    public interface IUserUtilsDatabaseSettings
    {
         string UserCollectionName { get; set; }
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }

    }
}