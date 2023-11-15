using XCRS.Core.Domain.Dtos;
using XCRS.Services.Core.Application.Bases.Endpoints;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Handlers.Requests;

namespace XCRS.Services.UserService.Application.Bases.Endpoints
{
    public class BaseUserQueryHandlerEndpoint<TRequest, TResponse> : BaseQueryHandlerEndpoint<TRequest, TResponse>
        where TRequest : BaseUserQueryHandlerReq
        where TResponse : Response
    {
    }
}
