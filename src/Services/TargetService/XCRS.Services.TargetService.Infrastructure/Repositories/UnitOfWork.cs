using MongoDB.Driver;
using XCRS.Services.Core.Domain.Interfaces.Infrastructure.Contexts;
using XCRS.Services.TargetService.Domain.Interfaces.Repositories;

namespace XCRS.Services.TargetService.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IMongoDatabase _context;

        public ITargetsRepository TargetRepository { get; private set; }

        public UnitOfWork(IMongoContext context)
        {
            _context = context.Database;
            TargetRepository = new TargetsRepository(context);
        }

        public async Task CompleteAsync()
        {
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
