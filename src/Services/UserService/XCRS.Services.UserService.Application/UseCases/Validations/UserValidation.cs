using XCRS.Core.Utility;
using XCRS.Services.UserService.Domain.Dtos;
using XCRS.Services.UserService.Domain.Enums;

namespace XCRS.Services.UserService.Application.UseCases.Validations
{
    public static class UserValidation
    {
        public static ValidationResult ValidateId(int id)
        {
            ValidationResult r = new ValidationResult
            {
                ErrorCode = string.Empty,
                ErrorValues = new[]
                {
                    ErrorUtil.GenerateErrorMessage(string.Empty, string.Empty)
                }
            };

            if (id < 1)
            {
                r.IsInvalid = true;
                r.ErrorCode = UserValidationErrorCodes.URER001.DisplayName;
                r.ErrorValues = new[]
                {
                    ErrorUtil.GenerateErrorMessage(UserValidationErrorCodes.URER001.DisplayName, UserValidationErrorCodes.URER001.DisplayMessage)
                };
            }

            return r;
        }
        public static ValidationResult ValidateLoginId(string loginId)
        {
            ValidationResult r = new ValidationResult
            {
                ErrorCode = string.Empty,
                ErrorValues = new[]
                {
                    ErrorUtil.GenerateErrorMessage(string.Empty, string.Empty)
                }
            };

            if (!(!string.IsNullOrEmpty(loginId) && loginId.Length > 2 && loginId.Length < 50))
            {
                r.IsInvalid = true;
                r.ErrorCode = UserValidationErrorCodes.URER002.DisplayName;
                r.ErrorValues = new[]
                {
                    ErrorUtil.GenerateErrorMessage(UserValidationErrorCodes.URER002.DisplayName, UserValidationErrorCodes.URER002.DisplayMessage)
                };
            }

            return r;
        }

        public static ValidationResult ValidateName(string name)
        {
            ValidationResult r = new ValidationResult
            {
                ErrorCode = string.Empty,
                ErrorValues = new[]
                {
                    ErrorUtil.GenerateErrorMessage(string.Empty, string.Empty)
                }
            };

            if (!(!string.IsNullOrWhiteSpace(name) && name.Length > 3 && name.Length < 50))
            {
                r.IsInvalid = true;
                r.ErrorCode = UserValidationErrorCodes.URER003.DisplayName;
                r.ErrorValues = new[]
                {
                    ErrorUtil.GenerateErrorMessage(UserValidationErrorCodes.URER003.DisplayName, UserValidationErrorCodes.URER003.DisplayMessage)
                };
            }

            return r;
        }

        public static ValidationResult ValidateAge(int age)
        {
            ValidationResult r = new ValidationResult
            {
                ErrorCode = string.Empty,
                ErrorValues = new[]
                {
                    ErrorUtil.GenerateErrorMessage(string.Empty, string.Empty)
                }
            };

            if (age == 0)
            {
                r.IsInvalid = true;
                r.ErrorCode = UserValidationErrorCodes.URER004.DisplayName;
                r.ErrorValues = new[]
                {
                    ErrorUtil.GenerateErrorMessage(UserValidationErrorCodes.URER004.DisplayName, UserValidationErrorCodes.URER004.DisplayMessage)
                };
            }

            return r;
        }
    }
}
