using XCRS.Services.TargetService.Domain.Entities;
using XCRS.Services.TargetService.Domain.Interfaces.Repositories;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Queries.Cases;

namespace XCRS.Services.TargetService.Application.UseCases.Queries
{
    public class TargetQuery 
    {
        private readonly IGetTargetCases _getTargetCases;
        public TargetQuery(IGetTargetCases getTargetCases)
        {
            _getTargetCases = getTargetCases;
        }

        public async Task<IEnumerable<Target>> GetTargets() 
            => await _getTargetCases.GetTargetsAsync().ConfigureAwait(false);
        public async Task<Target> GetTargetById(string id) 
            => await _getTargetCases.GetTargetByIdAsync(id).ConfigureAwait(false);
    }
}
