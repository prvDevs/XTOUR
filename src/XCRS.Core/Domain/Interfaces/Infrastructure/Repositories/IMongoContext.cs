using MongoDB.Driver;

namespace XCRS.Core.Domain.Interfaces.Infrastructure.Repositories
{
    public interface IMongoContext : IDisposable
    {
        IMongoDatabase Database { get; }
    }
}
