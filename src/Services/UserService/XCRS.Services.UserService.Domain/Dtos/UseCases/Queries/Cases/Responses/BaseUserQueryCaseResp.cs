using XCRS.Core.Domain.Dtos;
using XCRS.Core.Domain.Dtos.ServiceCases.Queries.Cases.Responses;

namespace XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Cases.Responses
{
    public class BaseUserQueryCaseResp : BaseQueryCaseResp
    {
        public bool IsSuccess { get; set; }
        public required ErrorResult ErrorResult { get; set; }
    }
}