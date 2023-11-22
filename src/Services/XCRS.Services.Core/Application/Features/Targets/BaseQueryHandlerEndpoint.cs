using FastEndpoints;
using XCRS.Core.Domain.Dtos;
using XCRS.Core.Domain.Dtos.ServiceCases.Queries.Handlers.Requests;

namespace XCRS.Services.Core.Application.Features.Targets
{
    public class BaseQueryHandlerEndpoint<TRequest, TResponse> : Endpoint<TRequest, TResponse>
        where TRequest : BaseQueryHandlerReq
        where TResponse : Response
    {
    }
}