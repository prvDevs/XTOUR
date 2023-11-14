
using XCRS.Core.Utility;
using XCRS.Services.UserService.Domain.Enums;

namespace XCRS.Core.Domain.Dtos
{
    public class ErrorResult
    {
        public bool IsInvalid { get; set; }
        public required string[] ErrorValues { get; set; }

        public void AddDefaultErrorValues()
        {
            ErrorValues = new[]
            {
                ErrorUtil.GenerateErrorMessage(CommonErrorCodes.Default.DisplayName, CommonErrorCodes.Default.DisplayMessage)
            };
        }
    }
}