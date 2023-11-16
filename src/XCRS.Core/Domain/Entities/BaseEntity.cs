using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace XCRS.Core.Entities.UserService.Core.Entities
{
    public interface IBaseEntity {

        [BsonRepresentation(BsonType.ObjectId)]
        public Object? Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
