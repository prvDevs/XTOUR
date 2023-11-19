using XCRS.Services.TargetService.Domain.Entities;

namespace XCRS.Services.TargetService.Domain.Interfaces.UseCases.Queries.Cases
{
    public interface IGetTargetCases
    {
        Task<IEnumerable<Target>> GetTargetsAsync();
        Task<Target> GetTargetByIdAsync(string id);
    }
}
