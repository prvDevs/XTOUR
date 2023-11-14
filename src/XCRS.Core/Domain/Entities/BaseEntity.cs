using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCRS.Core.Entities.UserService.Core.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public Object Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public interface IBaseEntity {
        [Column(Order = 1)]
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public Object Id { get; set; }

        [BsonElement("createdAt")]
        [Column(Order = 987)]
        public DateTime CreatedAt { get; set; }
    }
}
