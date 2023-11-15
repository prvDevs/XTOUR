namespace XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Handlers.Requests
{
    public class AddTargetHandlerReq : BaseTargetCommandHandlerReq
    {
        public required string Code { get; set; }
        public required TargetBiHandlerReq TargetBi { get; set; }
        public required TargetResourceHandlerReq TargetResource { get; set; }
    }

    public class TargetBiHandlerReq
    {
        public required string NameEn { get; set; }
        public required string NameKo { get; set; }
        public required string Domain { get; set; }
        public required string PhoneNo { get; set; }
        public required string Address { get; set; }
        public required string Ceo { get; set; }
        public required string Email { get; set; }
    }

    public class TargetResourceHandlerReq
    {
        public string? ColorSetCode { get; set; }
        public string? LoginBannerUrl { get; set; }
        public string? GnbBannerUrl { get; set; }
    }
}
