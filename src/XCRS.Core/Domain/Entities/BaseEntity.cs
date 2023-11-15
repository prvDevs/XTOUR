using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.IdGenerators;

namespace XCRS.Core.Entities.UserService.Core.Entities
{
    public class BaseEntity : IBaseEntity
    {
        [BsonElement("_id")]
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [Column(Order = 1)]
        public Object? Id { get; set; }
        [BsonElement("createdAt")]
        [Column(Order = 987)]
        public DateTime CreatedAt { get; set; }
    }

    public interface IBaseEntity {

        [BsonRepresentation(BsonType.ObjectId)]
        public Object? Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
