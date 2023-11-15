using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Domain.Enums;

namespace XCRS.Services.Core.Application.Customizations.Extensions
{
    public static class CustomErrorExtension
    {
        public static void AddCustomDefaultErrorMessage(this Response errorResult, string[] errorValues)
        {
            errorResult.AddErrorMessage(CommonErrorCodes.Default.DisplayName, CommonErrorCodes.Default.DisplayMessage, errorValues);
        }
        public static void AddCustomServiceValidatorErrorMessage(this Response errorResult, string[] errorValues)
        {
            errorResult.AddErrorMessage(CommonErrorCodes.BadRequest.DisplayName, CommonErrorCodes.BadRequest.DisplayMessage, errorValues);
        }
        public static void AddCustomServiceErrorMessage(this Response errorResult, string errorCode, string errorMessage, string[] errorValues)
        {
            errorResult.AddErrorMessage(errorCode, errorMessage, errorValues);
        }

        public static void AddCustomServiceException(this Response errorResult, Exception ex)
        {
            errorResult.AddErrorMessage(CommonErrorCodes.InternalException,
                new List<string>().ToArray(),
                $"{ex.Message}. InnerException: {ex.InnerException?.Message ?? string.Empty}",
                ex.StackTrace ?? string.Empty
            );
        }
    }
}


