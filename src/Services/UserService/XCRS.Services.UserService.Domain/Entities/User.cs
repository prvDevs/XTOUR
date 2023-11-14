using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using XCRS.Core.Entities.UserService.Core.Entities;

namespace XCRS.Services.UserService.Core.Entities
{
    public class User : BaseEntity
    {
        public required string LoginId { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }

        public int GetRealAge()
        {
            return Age + 1;
        }

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