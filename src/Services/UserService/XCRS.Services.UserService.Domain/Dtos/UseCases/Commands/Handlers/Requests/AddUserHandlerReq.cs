namespace XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Handlers.Requests
{
    public class AddUserHandlerReq : BaseUserCommandHandlerReq
    {
        public required string LoginId { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
    }
}
