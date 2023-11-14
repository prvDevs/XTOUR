using Microsoft.EntityFrameworkCore;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;

namespace XCRS.Services.UserService.Infrastructure.Repositories.UoW
{
    public class GenericUoW : IGenericUoW
    {
        protected readonly DbContext _dbContext;
        protected bool _disposed;

        public GenericUoW(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContext GetDbContext() { 
            return _dbContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        ~GenericUoW()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _dbContext.Dispose();
            _disposed = true;
        }
    }
}
