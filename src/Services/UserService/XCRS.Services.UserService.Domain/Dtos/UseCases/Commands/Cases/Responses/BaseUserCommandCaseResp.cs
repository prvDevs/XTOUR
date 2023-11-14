using XCRS.Core.Domain.Dtos;
using XCRS.Core.Domain.Dtos.ServiceCases.Commands.Cases.Responses;

namespace XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Cases.Responses
{
    public class BaseUserCommandCaseResp : BaseCommandCaseResp
    {
        public bool IsSuccess { get; set; }
        public required ErrorResult ErrorResult { get; set; }
    }
}