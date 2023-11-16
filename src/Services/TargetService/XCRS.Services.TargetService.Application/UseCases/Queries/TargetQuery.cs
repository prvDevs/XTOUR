using XCRS.Services.TargetService.Domain.Entities;
using XCRS.Services.TargetService.Domain.Interfaces.Repositories;

namespace XCRS.Services.TargetService.Application.UseCases.Queries
{
    public class TargetQuery 
    {
        private readonly IUnitOfWork _uow;
        public TargetQuery(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Target>> GetTargets() => await _uow.TargetRepository.GetAllAsync().ConfigureAwait(false);

        public async Task<Target> GetTargetById(string id) => await _uow.TargetRepository.FindByIdAsync(id).ConfigureAwait(false);
    }
}
