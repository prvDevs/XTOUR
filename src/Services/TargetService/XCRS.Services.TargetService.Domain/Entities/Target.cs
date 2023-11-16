
using FastEndpoints;
using HotChocolate;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations.Schema;
using XCRS.Core.Entities.UserService.Core.Entities;
using XCRS.Services.Core.Application.Customizations.Attributes;

namespace XCRS.Services.TargetService.Domain.Entities
{

    [BsonCollection("targets")]
    public class Target : IBaseEntity
    {
        [BsonElement("_id")]
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [Column(Order = 1)]
        public Object? Id { get; set; }
        //[GraphQLIgnore]
        [BsonElement("code")]
        public string? Code { get; set; }
        [BsonElement("targetBi")]
        public TargetBi? TargetBi { get; set; }
        [BsonElement("targetResource")]
        public TargetResource? TargetResource { get; set; }
        [BsonElement("createdAt")]
        [Column(Order = 987)]
        public DateTime CreatedAt { get; set; }
    }

    public class TargetBi {
        [BsonElement("nameEn")]
        public string? NameEn { get; set; }
        [BsonElement("nameKo")]
        public string? NameKo { get; set; }
        [BsonElement("domain")]
        public string? Domain { get; set; }
        [BsonElement("phoneNo")]
        public string? PhoneNo { get; set; }
        [BsonElement("address")]
        public string? Address { get; set; }
        [BsonElement("ceo")]
        public string? Ceo { get; set; }
        [BsonElement("email")]
        public string? Email { get; set; }
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
