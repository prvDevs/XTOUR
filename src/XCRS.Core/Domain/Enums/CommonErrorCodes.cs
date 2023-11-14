using XCRS.Core.Utility;

namespace XCRS.Services.UserService.Domain.Enums
{
    public partial record CommonErrorCodes : EnumerationUtil<CommonErrorCodes>
    {
        public string SystemMessage { get; set; }
        public string DisplayMessage { get; set; }

        public static new CommonErrorCodes FromValue(int value)
        {
            if (AllItems.Value.TryGetValue(value, out var matchingItem))
                return matchingItem;
            else if (AllItems.Value.TryGetValue(1, out var matchingItemByValue))
                //값이 없을 경우 기본값이 존재하는지 찾아 본다
                return matchingItemByValue;

            //기본값도 없으면 오류
            throw new InvalidOperationException($"'{value}' is not a valid value in {typeof(CommonErrorCodes)}");
        }

        public static new CommonErrorCodes FromDisplayName(string displayName)
        {
            if (AllItemsByName.Value.TryGetValue(displayName, out var matchingItem))
                return matchingItem;
            else if (AllItemsByName.Value.TryGetValue("Default", out var matchingItemByName))
                //값이 없을 경우 기본값이 존재하는지 찾아 본다
                return matchingItemByName;

            throw new InvalidOperationException($"'{displayName}' is not a valid display name in {typeof(CommonErrorCodes)}");
        }

        public static readonly CommonErrorCodes Default
           = new("System error","System error", 1, nameof(Default));
        public static readonly CommonErrorCodes APIServerError
           = new("API service error", "API service error", 2, nameof(APIServerError));
        public static readonly CommonErrorCodes UnAuthorize
           = new("UnAuthorize", "UnAuthorize", 3, nameof(UnAuthorize));
        public static readonly CommonErrorCodes InternalException
           = new("Internal exception", "Internal exception", 4, nameof(InternalException));
        public static readonly CommonErrorCodes Required
           = new("Missing required field", "Missing required field", 5, nameof(Required));
        public static readonly CommonErrorCodes SessionTimeout
           = new("Session timeout", "Session timeout", 6, nameof(SessionTimeout));
        public static readonly CommonErrorCodes InvalidFormat
           = new("Invalid format", "Invalid format", 7, nameof(InvalidFormat));
        public static readonly CommonErrorCodes BadRequest
           = new("Bad request", "Bad request", 8, nameof(BadRequest));

        public CommonErrorCodes(string systemMessage, string displayMessage, int value, string displayName) : base(value, displayName)
        {
            SystemMessage = systemMessage;
            DisplayMessage = displayMessage;
        }
    }
}