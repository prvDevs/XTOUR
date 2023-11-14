using XCRS.Services.Core.Domain.Interfaces.Infrastructure.Repository;
using XCRS.Services.TargetService.Domain.Entities;

namespace XCRS.Services.TargetService.Domain.Interfaces.Repositories
{
    public interface ITargetsRepository : IGenericMongoDbRepository<Target>
    {
    }
}
