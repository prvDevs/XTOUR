using XCRS.Core.Domain.Dtos;
using XCRS.Services.Core.Application.Features.Targets;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Handlers.Requests;

namespace XCRS.Services.TargetService.Application.Features.Targets
{
    public class BaseTargetCommandHandlerEndpoint<TRequest, TResponse> : BaseCommandHandlerEndpoint<TRequest, TResponse>
        where TRequest : BaseTargetCommandHandlerReq
        where TResponse : Response
    {
    }
}
