using XCRS.Core.Utility;

namespace XCRS.Services.UserService.Domain.Enums
{
    public record UserValidationErrorCodes : EnumerationUtil<UserValidationErrorCodes>
    {
        public string SystemMessage { get; set; }
        public string DisplayMessage { get; set; }


        public static readonly UserValidationErrorCodes URER001
            = new("The User Id is invalid", "The User Id is invalid.", 1, nameof(URER001));
        public static readonly UserValidationErrorCodes URER002
            = new("The User LoginId is invalid", "The User LoginId is invalid.", 2, nameof(URER002));
        public static readonly UserValidationErrorCodes URER003
            = new("The User Name is invalid", "The User Name is invalid.", 3, nameof(URER003));
        public static readonly UserValidationErrorCodes URER004
            = new("The User Age is invalid", "The User Age is invalid.", 4, nameof(URER004));

        public UserValidationErrorCodes(string systemMessage, string displayMessage, int value, string displayName) : base(value, displayName)
        {
            SystemMessage = systemMessage;
            DisplayMessage = displayMessage;
        }
    }
}
