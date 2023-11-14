using Microsoft.EntityFrameworkCore;

namespace XCRS.Core.Domain.Interfaces.Infrastructure.Repositories
{
    public interface IGenericUoW : IDisposable
    {
        DbContext GetDbContext();
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
