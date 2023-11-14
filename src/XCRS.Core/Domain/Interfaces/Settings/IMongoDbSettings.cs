namespace XCRS.Core.Domain.Interfaces.Settings
{
    public interface IMongoDbSettings
    {
        string GetConnectionString();

        string GetDatabaseName();
    }
}
