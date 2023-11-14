namespace XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Cases.Requests
{
    public class GetUserByIdCaseReq : BaseUserQueryCaseReq
    {
        public int Id { get; set; }
    }
}
