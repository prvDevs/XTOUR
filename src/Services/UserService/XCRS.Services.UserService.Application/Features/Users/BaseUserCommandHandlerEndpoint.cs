using XCRS.Core.Domain.Dtos;
using XCRS.Services.Core.Application.Features.Targets;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Handlers.Requests;

namespace XCRS.Services.UserService.Application.Features.Users
{
    public class BaseUserCommandHandlerEndpoint<TRequest, TResponse> : BaseCommandHandlerEndpoint<TRequest, TResponse>
        where TRequest : BaseUserCommandHandlerReq
        where TResponse : Response
    {
    }
}
