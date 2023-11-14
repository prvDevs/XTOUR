namespace XCRS.Services.UserService.Domain.Interfaces.Settings
{
    public interface IMongoDbSettings
    {
        string GetConnectionString();

        string GetDatabaseName();
    }
}
