using MongoDB.Driver;
namespace XCRS.Services.Core.Domain.Interfaces.Infrastructure.Contexts
{
    public interface IMongoContext : IDisposable
    {
        IMongoDatabase Database { get; }
    }
}
