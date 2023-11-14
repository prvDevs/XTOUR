
using MongoDB.Bson.Serialization.Attributes;
using XCRS.Core.Entities.UserService.Core.Entities;
using XCRS.Services.Core.Application.Customizations.Attributes;

namespace XCRS.Services.TargetService.Domain.Entities
{

    [BsonCollection("targets")]
    public class Target : BaseEntity
    {
        [BsonElement("name")]
        public required string Name { get; set; }
        [BsonElement("nameKo")]
        public required string NameKo { get; set; }
        [BsonElement("domain")]
        public required string Domain { get; set; }
        [BsonElement("phoneNo")]
        public required string PhoneNo { get; set; }
        [BsonElement("address")]
        public required string Address { get; set; }
        [BsonElement("ceo")]
        public required string Ceo { get; set; }
        [BsonElement("email")]
        public required string Email { get; set; }
        [BsonElement("targetResource")]
        public required TargetResource TargetResource { get; set; }
    }

    public class TargetResource {
        [BsonElement("colorSetCode")]
        public string? ColorSetCode { get; set; }
        [BsonElement("loginBannerUrl")]
        public string? LoginBannerUrl {  get; set; }
        [BsonElement("gnbBannerUrl")]
        public string? GnbBannerUrl { get; set; }

    }
}
