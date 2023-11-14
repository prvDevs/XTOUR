using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Handlers.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Handlers.Responses;

namespace XCRS.Services.UserService.Domain.Interfaces.Application.UseCases.Commands
{
    public interface IUserCommandHandler
    {
        Task<Response<AddUserHandlerResp>> AddUserHandlerAsync(AddUserHandlerReq req, CancellationToken cancellationToken);
    }
}
