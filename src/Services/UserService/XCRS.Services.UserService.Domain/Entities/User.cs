using HotChocolate;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations.Schema;
using XCRS.Core.Entities.UserService.Core.Entities;

namespace XCRS.Services.UserService.Core.Entities
{
    public class User : IBaseEntity
    {
        //[GraphQLType(typeof(IdType))]
        [BsonElement("_id")]
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [Column(Order = 1)]
        public object? Id { get; set; }
        public required string LoginId { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }

        public int GetRealAge()
        {
            return Age + 1;
        }
        [BsonElement("createdAt")]
        [Column(Order = 987)]
        public DateTime CreatedAt { get; set; }

        [Column(Order = 989)]
        [BsonElement("createdBy")]
        public Object? CreatedBy { get; set; }

        [Column(Order = 991)]
        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [Column(Order = 993)]
        [BsonElement("updatedBy")]
        public Object? UpdatedBy { get; set; }

        [Column(Order = 995)]
        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }

        [Column(Order = 997)]
        [BsonElement("deletedAt")]
        public DateTime DeletedAt { get; set; }

        [Column(Order = 999)]
        [BsonElement("deletedBy")]
        public Object? DeletedBy { get; set; }
    }
}
