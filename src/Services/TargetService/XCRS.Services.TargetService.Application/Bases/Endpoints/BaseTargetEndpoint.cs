using XCRS.Core.Domain.Dtos;
using XCRS.Services.Core.Application.Bases.Endpoints;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Handlers.Requests;

namespace XCRS.Services.TargetService.Application.Bases.Endpoints
{
    public class BaseTargetEndpoint<TRequest, TResponse> : BaseCommandHandlerEndpoint<TRequest, TResponse>
        where TRequest : BaseTargetCommandHandlerReq
        where TResponse : Response
    {
    }
}
