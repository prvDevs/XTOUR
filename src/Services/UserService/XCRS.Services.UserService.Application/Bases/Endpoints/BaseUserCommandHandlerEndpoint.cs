using XCRS.Core.Domain.Dtos;
using XCRS.Services.Core.Application.Bases.Endpoints;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Handlers.Requests;

namespace XCRS.Services.UserService.Application.Bases.Endpoints
{
    public class BaseUserCommandHandlerEndpoint<TRequest, TResponse> : BaseCommandHandlerEndpoint<TRequest, TResponse>
        where TRequest : BaseUserCommandHandlerReq
        where TResponse : Response
    {
    }
}
