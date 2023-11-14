using MongoDB.Driver;

namespace XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories
{
    public interface IMongoContext : IDisposable
    {
        IMongoDatabase Database { get; }
    }
}
