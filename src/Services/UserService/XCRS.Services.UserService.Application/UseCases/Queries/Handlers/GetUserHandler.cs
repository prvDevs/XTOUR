using XCRS.Services.Core.Application.Customizations.Extensions;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;
using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Application.UseCases.Queries.Cases;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Handlers.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Cases.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Cases.Responses;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Handlers.Responses;

namespace XCRS.Services.UserService.Application.UseCases.Queries.Handlers
{
    /// <summary>
    /// This is a test code.
    /// It's not confirmed, but it'll be modified to target a difference DB.
    /// 20231101
    /// </summary>
    public class GetUserHandler
    {
        private readonly INewEagle3UoW _newEagle3UoW;
        public GetUserHandler(
            INewEagle3UoW newEagle3UoW
            )
        {
            _newEagle3UoW = newEagle3UoW;
        }

        public async Task<Response<GetUserHandlerResp>> HandleAsync(GetUserHandlerReq req, CancellationToken cancellationToken)
        {
            #region Init
            Response<GetUserHandlerResp> r = new();
            GetUserCases getUserCases = new(_newEagle3UoW);
            #endregion

            try
            {
                #region GetUser                
                GetUserByIdCaseReq getUserByIdCaseReq = new()
                {
                    Id = req.Id,
                };
                GetUserByIdCaseResp getUserByIdCaseResp = await getUserCases.GetUserByIdCase(getUserByIdCaseReq);
                if (!getUserByIdCaseResp.IsSuccess)
                {
                    if (getUserByIdCaseResp.ErrorResult.IsInvalid)
                        r.AddCustomServiceValidatorErrorMessage(getUserByIdCaseResp.ErrorResult.ErrorValues);
                    else
                        r.AddCustomDefaultErrorMessage(getUserByIdCaseResp.ErrorResult.ErrorValues);

                    return r;
                }
                #endregion

                #region Result
                if (getUserByIdCaseResp.Id != null)
                    r.Result = new GetUserHandlerResp
                    {
                        Id = getUserByIdCaseResp.Id,
                        LoginId = getUserByIdCaseResp.LoginId,
                        Name = getUserByIdCaseResp.Name,
                        Age = getUserByIdCaseResp.Age,
                        RealAge = getUserByIdCaseResp.RealAge
                    };
                #endregion
            }
            catch (Exception ex)
            {
                r.AddCustomServiceException(ex);
            }

            return r;
        }
    }
}
