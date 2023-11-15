using FastEndpoints;
using XCRS.Core.Domain.Dtos;
using XCRS.Core.Domain.Dtos.ServiceCases.Commands.Handlers.Requests;
using XCRS.Services.Core.Domain.Dtos.Features;

namespace XCRS.Services.Core.Application.Bases.Endpoints
{
    public class BaseCommandHandlerEndpoint<TRequest, TResponse> : Endpoint<TRequest, TResponse>
        where TRequest : BaseCommandHandlerReq
        where TResponse : Response
    {
    }
}