using MongoDB.Driver;
using XCRS.Services.Core.Domain.Interfaces.Infrastructure.Contexts;
using XCRS.Services.TargetService.Domain.Settings;

namespace XCRS.Services.TargetService.Infrastructure.Contexts
{
    public class TargetDbContext : IMongoContext
    {
        public TargetDbContext(ITargetDbSettings settings)
        {
            Console.WriteLine($"=====================> [{nameof(TargetDbContext)}] Mongo connection: {settings.ConnectionString}");
            var client = new MongoClient(settings.ConnectionString);
            Database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoDatabase Database { get; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}