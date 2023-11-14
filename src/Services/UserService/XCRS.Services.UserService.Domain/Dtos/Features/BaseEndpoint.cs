using FastEndpoints;
using XCRS.Core.Domain.Dtos;

namespace XCRS.Services.UserService.Domain.Dtos.Features
{
    public class BaseEndpoint<TRequest, TResponse> : Endpoint<TRequest, TResponse> 
        where TRequest : BaseReq
        where TResponse : Response
    {
    }
}