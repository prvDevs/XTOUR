using XCRS.Core.Utility;

namespace XCRS.Services.UserService.Domain.Enums
{
    public partial record UserErrorCodes : EnumerationUtil<UserErrorCodes>
    {
        public string SystemMessage { get; set; }
        public string DisplayMessage { get; set; }

        public UserErrorCodes(string systemMessage, string displayMessage, int value, string displayName) : base(value, displayName)
        {
            SystemMessage = systemMessage;
            DisplayMessage = displayMessage;
        }
    }
}