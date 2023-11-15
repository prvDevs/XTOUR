using XCRS.Core.Domain.Dtos;
using XCRS.Core.Utility;
using XCRS.Services.TargetService.Domain.Enums;

namespace XCRS.Services.TargetService.Application.TargetCases.Validations
{
    public static class TargetValidation
    {
        public static ValidationResult ValidateCode(string code)
        {
            ValidationResult r = new ValidationResult
            {
                ErrorCode = string.Empty,
                ErrorValues =
                [
                    ErrorUtil.GenerateErrorMessage(string.Empty, string.Empty)
                ]
            };

            if (string.IsNullOrWhiteSpace(code))
            {
                r.IsInvalid = true;
                r.ErrorCode = TargetValidationErrorCodes.TAGT001.DisplayName;
                r.ErrorValues =
                [
                    ErrorUtil.GenerateErrorMessage(TargetValidationErrorCodes.TAGT001.DisplayName, TargetValidationErrorCodes.TAGT001.DisplayMessage)
                ];
            }

            return r;
        }
        public static ValidationResult ValidateNameEn(string nameEn)
        {
            ValidationResult r = new ValidationResult
            {
                ErrorCode = string.Empty,
                ErrorValues =
                [
                    ErrorUtil.GenerateErrorMessage(string.Empty, string.Empty)
                ]
            };

            if (string.IsNullOrWhiteSpace(nameEn))
            {
                r.IsInvalid = true;
                r.ErrorCode = TargetValidationErrorCodes.TAGT002.DisplayName;
                r.ErrorValues =
                [
                    ErrorUtil.GenerateErrorMessage(TargetValidationErrorCodes.TAGT002.DisplayName, TargetValidationErrorCodes.TAGT002.DisplayMessage)
                ];
            }

            return r;
        }

        public static ValidationResult ValidateNameKo(string nameKo)
        {
            ValidationResult r = new ValidationResult
            {
                ErrorCode = string.Empty,
                ErrorValues =
                [
                    ErrorUtil.GenerateErrorMessage(string.Empty, string.Empty)
                ]
            };

            if (string.IsNullOrWhiteSpace(nameKo))
            {
                r.IsInvalid = true;
                r.ErrorCode = TargetValidationErrorCodes.TAGT003.DisplayName;
                r.ErrorValues =
                [
                    ErrorUtil.GenerateErrorMessage(TargetValidationErrorCodes.TAGT003.DisplayName, TargetValidationErrorCodes.TAGT003.DisplayMessage)
                ];
            }

            return r;
        }
    }
}
