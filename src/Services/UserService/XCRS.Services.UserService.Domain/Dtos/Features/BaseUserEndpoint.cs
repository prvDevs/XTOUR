using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Domain.Dtos.Features.User;

namespace XCRS.Services.UserService.Domain.Dtos.Features
{
    public class BaseUserEndpoint<TRequest, TResponse> : BaseEndpoint<TRequest, TResponse>
        where TRequest : BaseUserReq
        where TResponse : Response
    {
    }
}
