using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using HotChocolate;
using HotChocolate.Types;

namespace XCRS.Core.Entities.UserService.Core.Entities
{
    public interface IBaseEntity {

        [BsonRepresentation(BsonType.ObjectId)]
        //[BsonElement("_id")]
        public object? Id { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
