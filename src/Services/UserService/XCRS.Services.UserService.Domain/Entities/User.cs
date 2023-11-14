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
    }
}