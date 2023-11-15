namespace XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Cases.Requests
{
    public class AddTargetCaseReq : BaseTargetCommandCaseReq
    {
        public required string Code { get; set; }
        public required TargetBiCaseReq TargetBi { get; set; }
        public required TargetResourceCaseReq TargetResource { get; set; }
    }

    public class TargetBiCaseReq {
        public required string NameEn { get; set; }
        public required string NameKo { get; set; }
        public required string Domain { get; set; }
        public required string PhoneNo { get; set; }
        public required string Address { get; set; }
        public required string Ceo { get; set; }
        public required string Email { get; set; }
    }

    public class TargetResourceCaseReq
    {
        public string? ColorSetCode { get; set; }
        public string? LoginBannerUrl { get; set; }
        public string? GnbBannerUrl { get; set; }
    }
}
