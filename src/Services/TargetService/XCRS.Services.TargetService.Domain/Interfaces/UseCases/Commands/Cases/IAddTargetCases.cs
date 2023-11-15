using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Cases.Requests;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Cases.Responses;

namespace XCRS.Services.TargetService.Domain.Interfaces.UseCases.Commands.Cases
{
    public interface IAddTargetCases
    {
        Task<AddTargetCaseResp> AddTargetCase(AddTargetCaseReq req, CancellationToken cancellationToken);
    }
}
