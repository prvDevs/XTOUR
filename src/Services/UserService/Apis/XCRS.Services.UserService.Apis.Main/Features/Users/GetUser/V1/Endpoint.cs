using Microsoft.AspNetCore.Mvc;
using System.Net;
using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Application.Features.Users;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Handlers.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Queries.Handlers.Responses;
using XCRS.Services.UserService.Domain.Interfaces.Application.UseCases.Quereis;

namespace XCRS.Services.UserService.Apis.Main.Features.Users.GetUser.V1
{
    [ProducesResponseType(typeof(Response<GetUserHandlerResp?>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
    public class GetUser : BaseUserQueryHandlerEndpoint<GetUserHandlerReq, Response<GetUserHandlerResp>>
    {
        private readonly IUserQueryHandler _userQueryHandler;
   
        public GetUser(IUserQueryHandler userQueryHandler)
        {
            _userQueryHandler = userQueryHandler;
        }
        
        public override void Configure()
        {
            //Version(1);
            Get("user/{id}");
            AllowAnonymous();
            //PreProcessors(new SetUserClaimsPre<Request>());
            //Policies(nameof(DefaultPolicyConst.NeedPtId));
            //Options(x => x.RequireAuthorization(""));
            //Description(b => b.ExcludeFromDescription());

            //Summary(s =>
            //{
            //    s.Summary = "get user";
            //    s.Description = "blablabla";
            //    s.ExampleRequest = new Request
            //    {
            //        Id = 0
            //    };

            //});
        }

        public override async Task HandleAsync(GetUserHandlerReq req, CancellationToken cancellationToken)
        {
            GetUserHandlerReq getUserHandlerReq = new()
            {
                Id = req.Id,
            };
            Response<GetUserHandlerResp> response = await _userQueryHandler.GetUserHandlerAsync(getUserHandlerReq, cancellationToken);

            await SendAsync(response);
        }
    }
}
