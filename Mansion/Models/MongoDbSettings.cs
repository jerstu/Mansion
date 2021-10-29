namespace Mansion.Models
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string PatternsCollectionName { get; set; }
        public string BanksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMongoDbSettings
    {
        string PatternsCollectionName { get; set; }
        string BanksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}