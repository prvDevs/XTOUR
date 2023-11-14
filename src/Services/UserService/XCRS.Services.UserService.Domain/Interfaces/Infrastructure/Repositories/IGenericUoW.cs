using Microsoft.EntityFrameworkCore;

namespace XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories
{
    public interface IGenericUoW : IDisposable
    {
        DbContext GetDbContext();
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
