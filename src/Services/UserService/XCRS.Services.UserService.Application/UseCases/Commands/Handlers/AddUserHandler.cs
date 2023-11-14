using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Application.Customizations.Extensions;
using XCRS.Services.UserService.Application.UseCases.Commands.Cases;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Cases.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Cases.Responses;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Handlers.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Handlers.Responses;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;

namespace Modetour.XCRS.Services.UserService.Application.UseCases.Commands.Handlers
{

    //에러 처리, 유효성 검사 등, 재설계 예정
    public class AddUserHandler
    {
        private readonly INewEagle3UoW _newEagle3UoW;
        public AddUserHandler(
            INewEagle3UoW newEagle3UoW
            )
        {
            _newEagle3UoW = newEagle3UoW;
        }

        public async Task<Response<AddUserHandlerResp>> HandleAsync(AddUserHandlerReq req, CancellationToken cancellationToken)
        {
            #region Init
            Response<AddUserHandlerResp> r = new();
            AddUserCases addUserCases = new(_newEagle3UoW); 
            #endregion

            try
            {
                using (var transaction = _newEagle3UoW.GetDbContext().Database.BeginTransaction())
                {
                    #region AddUserCase              
                    AddUserCaseReq addUserCaseReq = new()
                    {
                        LoginId = req.LoginId,
                        Name = req.Name,
                        Age = req.Age
                    };
                    AddUserCaseResp addUserCaseResp = await addUserCases.AddUserCase(addUserCaseReq, cancellationToken).ConfigureAwait(false);
                    if (!addUserCaseResp.IsSuccess)
                    {
                        if (addUserCaseResp.ErrorResult.IsInvalid)
                            r.AddUserServiceValidatorErrorMessage(addUserCaseResp.ErrorResult.ErrorValues);
                        return r;
                    }
                    #endregion

                    #region Something
                    //if (somethingFailed)
                    //{
                    //    transaction.Rollback();
                    //    return r;
                    //} 
                    #endregion

                    #region Result
                    transaction.Commit();
                    r.Result = new AddUserHandlerResp
                    {
                        Id = addUserCaseResp.Id
                    };
                    #endregion
                }               
            }
            catch (Exception ex)
            {
                r.AddUserServiceException(ex);
            }

            return r;
        }


    }
}