
namespace XCRS.Services.UserService.Domain.Dtos.Features.User
{
    public class AddUserReq : BaseUserReq
    {
        public required string LoginId { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
    }

}
