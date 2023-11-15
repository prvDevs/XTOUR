using XCRS.Core.Domain.Dtos;
using XCRS.Core.Domain.Dtos.ServiceCases.Commands.Cases.Responses;

namespace XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Cases.Responses
{
    public class BaseTargetCommandCaseResp : BaseCommandCaseResp
    {
        public bool IsSuccess { get; set; }
        public required ErrorResult ErrorResult { get; set; }
    }
}