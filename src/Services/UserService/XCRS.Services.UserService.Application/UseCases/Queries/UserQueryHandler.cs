using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Application.UseCases.Queries.Handlers;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Handlers.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Handlers.Responses;
using XCRS.Services.UserService.Domain.Interfaces.Application.UseCases.Quereis;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;

namespace XCRS.Services.UserService.Application.UseCases.Queries
{
    public class UserQueryHandler : IUserQueryHandler
    {
        private readonly INewEagle3UoW _newEagle3UoW;
        public UserQueryHandler(INewEagle3UoW newEagle3UoW)
        {
            _newEagle3UoW = newEagle3UoW;
        }

        #region Get
        public async Task<Response<GetUserHandlerResp>> GetUserHandlerAsync(GetUserHandlerReq req, CancellationToken cancellationToken)
        {
            return await new GetUserHandler(_newEagle3UoW).HandleAsync(req, cancellationToken);
        }
        #endregion

        #region Find

        #endregion
    }
}