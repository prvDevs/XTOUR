using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Domain.Enums;

namespace XCRS.Services.UserService.Application.Customizations.Extensions
{
    public static class UserErrorExtension
    {
        public static void AddUserDefaultErrorMessage(this Response errorResult, string[] errorValues)
        {
            errorResult.AddErrorMessage(CommonErrorCodes.Default.DisplayName, CommonErrorCodes.Default.DisplayMessage, errorValues);
        }
        public static void AddUserServiceValidatorErrorMessage(this Response errorResult, string[] errorValues)
        {
            errorResult.AddErrorMessage(CommonErrorCodes.BadRequest.DisplayName, CommonErrorCodes.BadRequest.DisplayMessage, errorValues);
        }
        public static void AddUserServiceErrorMessage(this Response errorResult, string errorCode, string errorMessage, string[] errorValues)
        {
            errorResult.AddErrorMessage(errorCode, errorMessage, errorValues);
        }

        public static void AddUserServiceException(this Response errorResult, Exception ex)
        {
            errorResult.AddErrorMessage(CommonErrorCodes.InternalException,
                new List<string>().ToArray(),
                $"{ex.Message}. InnerException: {ex.InnerException?.Message ?? string.Empty}",
                ex.StackTrace ?? string.Empty
            );
        }
    }
}
