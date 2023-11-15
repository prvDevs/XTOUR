using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Application.UseCases.Validations;
using XCRS.Services.UserService.Core.Entities;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Cases.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Cases.Responses;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;

namespace XCRS.Services.UserService.Application.UseCases.Commands.Cases
{
    public class AddUserCases
    {
        protected readonly INewEagle3UoW _newEagle3UoW;

        public AddUserCases(
            INewEagle3UoW newEagle3UoW)
        {
            _newEagle3UoW = newEagle3UoW ?? throw new ArgumentNullException(nameof(newEagle3UoW));
        }

        public async Task<AddUserCaseResp> AddUserCase(AddUserCaseReq req, CancellationToken cancellationToken)
        {
            #region Init
            AddUserCaseResp r = new AddUserCaseResp
            {
                ErrorResult = new ErrorResult { ErrorValues = new string[0] }
            };             
            #endregion

            #region validation       
            ValidationResult loginIdValidationResult = UserValidation.ValidateLoginId(req.LoginId);
            ValidationResult NameValidationResult = UserValidation.ValidateName(req.Name);
            ValidationResult ageValidationResult = UserValidation.ValidateAge(req.Age);

            if (loginIdValidationResult.IsInvalid && loginIdValidationResult.ErrorValues.Length > 0)
                r.ErrorResult.ErrorValues = r.ErrorResult.ErrorValues.Concat(loginIdValidationResult.ErrorValues).ToArray();
            if (NameValidationResult.IsInvalid && loginIdValidationResult.ErrorValues.Length > 0)
                r.ErrorResult.ErrorValues = r.ErrorResult.ErrorValues.Concat(NameValidationResult.ErrorValues).ToArray();
            if (ageValidationResult.IsInvalid && loginIdValidationResult.ErrorValues.Length > 0)
                r.ErrorResult.ErrorValues = r.ErrorResult.ErrorValues.Concat(ageValidationResult.ErrorValues).ToArray();

            if (r.ErrorResult.ErrorValues != null && r.ErrorResult.ErrorValues.Length > 0)
            {
                r.ErrorResult.IsInvalid = true; 
                return r;
            }
            #endregion

            #region Case
            User user = new User
            {
                LoginId = req.LoginId,
                Name = req.Name,
                Age = req.Age
            };

            _newEagle3UoW.TestRepository().Add(user);
            await _newEagle3UoW.CommitAsync(cancellationToken).ConfigureAwait(false);
            #endregion

            #region Result
            r.Id = user.Id;
            if (user.Id == null)
                r.ErrorResult.AddDefaultErrorValues();
            else
                r.IsSuccess = true; 
            #endregion

            return r;
        }

        //public async Task<User> AddUserBulk(AddUserBulkReq req, CancellationToken cancellationToken)
        //{
        //}
    }
}