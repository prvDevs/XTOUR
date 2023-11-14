using Modetour.XCRS.Services.UserService.Application.UseCases.Commands.Handlers;
using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Handlers.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Handlers.Responses;
using XCRS.Services.UserService.Domain.Interfaces.Application.UseCases.Commands;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;

namespace XCRS.Services.UserService.Application.UseCases.Commands
{
    public class UserCommandHandler : IUserCommandHandler
    {
        private readonly INewEagle3UoW _newEagle3UoW;
        public UserCommandHandler(INewEagle3UoW newEagle3UoW)
        {
            _newEagle3UoW = newEagle3UoW;
        }

        #region Add
        public async Task<Response<AddUserHandlerResp>> AddUserHandlerAsync(AddUserHandlerReq req, CancellationToken cancellationToken)
        {
            return await new AddUserHandler(_newEagle3UoW).HandleAsync(req, cancellationToken);
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

        #region Send

        #endregion

        #region Upload

        #endregion
    }
}
