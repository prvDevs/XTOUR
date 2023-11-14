using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCRS.Core.Entities.UserService.Core.Entities
{
    public class BaseEntity
    {
        [Column(Order = 1)]
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]        
        public Object Id { get; set; }
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
        public Object? UpdatedBy { get; set;}

        [Column(Order = 995)]
        [BsonElement("isDeleted")]        
        public bool IsDeleted { get; set; }

        [Column(Order = 997)]
        [BsonElement("deletedAt")]        
        public DateTime DeletedAt { get; set; }

        [Column(Order = 999)]
        [BsonElement("deletedBy")]        
        public Object? DeletedBy { get; set;}
    }
}
