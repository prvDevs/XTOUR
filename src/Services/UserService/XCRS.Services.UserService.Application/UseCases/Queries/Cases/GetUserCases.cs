using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Application.UseCases.Validations;
using XCRS.Services.UserService.Core.Entities;
using XCRS.Services.UserService.Domain.Dtos;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Cases.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Cases.Responses;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;

namespace XCRS.Services.UserService.Application.UseCases.Queries.Cases
{
    public class GetUserCases
    {
        protected readonly INewEagle3UoW _newEagle3UoW;
        public GetUserCases(
            INewEagle3UoW newEagle3UoW)
        {
            _newEagle3UoW = newEagle3UoW ?? throw new ArgumentNullException(nameof(newEagle3UoW));
        }
        public async Task<GetUserByIdCaseResp> GetUserByIdCase(GetUserByIdCaseReq req)
        {
            #region Init
            GetUserByIdCaseResp r = new()
            {
                ErrorResult = new ErrorResult { ErrorValues = new string[0] }
            };
            #endregion

            #region validation       
            ValidationResult idValidationResult = UserValidation.ValidateId(req.Id);

            if (idValidationResult.IsInvalid && idValidationResult.ErrorValues.Length > 0)
                r.ErrorResult.ErrorValues = r.ErrorResult.ErrorValues.Concat(idValidationResult.ErrorValues).ToArray();

            if (r.ErrorResult.ErrorValues != null && r.ErrorResult.ErrorValues.Length > 0)
            {
                r.ErrorResult.IsInvalid = true;
                return r;
            }
            #endregion

            #region Case
            User? user = await _newEagle3UoW.TestRepository().GetByIdAsync(req.Id);
            #endregion

            #region Result
            if (user != null)
            {
                r.Id = user.Id;
                r.LoginId = user.LoginId;
                r.Name = user.Name;
                r.Age = user.Age;
                r.RealAge = user.GetRealAge();
            }
            r.IsSuccess = true;
            #endregion

            return r;
        }
    }
}
