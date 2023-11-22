using FastEndpoints;
using XCRS.Core.Domain.Dtos;
using XCRS.Core.Domain.Dtos.ServiceCases.Commands.Handlers.Requests;

namespace XCRS.Services.Core.Application.Features.Targets
{
    public class BaseCommandHandlerEndpoint<TRequest, TResponse> : Endpoint<TRequest, TResponse>
        where TRequest : BaseCommandHandlerReq
        where TResponse : Response
    {
    }
}