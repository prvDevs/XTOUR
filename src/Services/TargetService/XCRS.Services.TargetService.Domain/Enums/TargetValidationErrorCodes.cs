using XCRS.Core.Utility;

namespace XCRS.Services.TargetService.Domain.Enums
{
    public record TargetValidationErrorCodes : EnumerationUtil<TargetValidationErrorCodes>
    {
        public string SystemMessage { get; set; }
        public string DisplayMessage { get; set; }


        public static readonly TargetValidationErrorCodes TAGT001
           = new("The Target Code is invalid", "The Target Code is invalid.", 1, nameof(TAGT001));
        public static readonly TargetValidationErrorCodes TAGT002
            = new("The Target NameEn is invalid", "The Target NameEn is invalid.", 1, nameof(TAGT002));
        public static readonly TargetValidationErrorCodes TAGT003
            = new("The Target NameKo is invalid", "The Target NameKo is invalid.", 2, nameof(TAGT003));

        public TargetValidationErrorCodes(string systemMessage, string displayMessage, int value, string displayName) : base(value, displayName)
        {
            SystemMessage = systemMessage;
            DisplayMessage = displayMessage;
        }
    }
}
