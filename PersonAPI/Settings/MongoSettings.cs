namespace PersonAPI.Settings
{
    public class MongoSettings : IMongoSettings
    {
        public string ConnectionString { get; set; }
    }

    public interface IMongoSettings 
    {
        public string ConnectionString { get; set; }
    }
}
