namespace XCRS.Services.Core.Domain.Settings
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }

    public class MongoDbSettings : IMongoDbSettings
    {
        public required string DatabaseName { get; set; }
        public required string ConnectionString { get; set; }
    }
}
