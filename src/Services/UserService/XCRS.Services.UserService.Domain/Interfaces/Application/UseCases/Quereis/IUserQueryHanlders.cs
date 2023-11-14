using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Handlers.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Handlers.Responses;

namespace XCRS.Services.UserService.Domain.Interfaces.Application.UseCases.Quereis
{
    public interface IUserQueryHandler
    {
        Task<Response<GetUserHandlerResp>> GetUserHandlerAsync(GetUserHandlerReq req, CancellationToken cancellationToken);
    }
}
