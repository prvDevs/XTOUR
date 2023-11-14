namespace XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Handlers.Responses
{
    public class GetUserHandlerResp
    {
        public Object? Id { get; set; }
        public string? LoginId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int RealAge { get; set; }
    }
}