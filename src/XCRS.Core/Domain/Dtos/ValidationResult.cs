namespace XCRS.Core.Domain.Dtos
{
    public class ValidationResult
    {
        public bool IsInvalid { get; set; }
        public required string ErrorCode { get; set; }
        public required string[] ErrorValues { get; set; }
    }
}
