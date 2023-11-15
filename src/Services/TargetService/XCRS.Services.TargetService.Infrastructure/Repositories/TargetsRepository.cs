using XCRS.Services.Core.Infrastructure.Repository;
using XCRS.Services.TargetService.Domain.Entities;
using XCRS.Services.TargetService.Domain.Interfaces.Repositories;
using XCRS.Services.TargetService.Domain.Settings;

namespace XCRS.Services.TargetService.Infrastructure.Repositories
{
    public class TargetsRepository : GenericMongoDbRepository<Target>, ITargetsRepository
    {
        public TargetsRepository(ITargetDbSettings settings) :  base(settings){ 
        }
    }
}
