namespace XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Cases.Requests
{
    public class AddUserCaseReq : BaseUserCommandCaseReq
    {
        public required string LoginId { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
    }
}
