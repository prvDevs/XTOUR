using Microsoft.AspNetCore.Mvc;
using XCRS.Services.UserService.Domain.Interfaces.Application.UseCases.Commands;
using System.Net;
using XCRS.Core.Domain.Dtos;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Handlers.Requests;
using XCRS.Services.UserService.Domain.Dtos.UseCases.Commands.Handlers.Responses;
using XCRS.Services.UserService.Application.Features.Users;

namespace XCRS.Services.UserService.Apis.Main.Features.Users.AddUser.V1
{
    [ProducesResponseType(typeof(Response<AddUserHandlerResp>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
    public class AddUserAsync : BaseUserCommandHandlerEndpoint<AddUserHandlerReq, Response<AddUserHandlerResp>>
    {
        private readonly IUserCommandHandler _userCommandHandler;

        
        public AddUserAsync(IUserCommandHandler userCommandHandler)
        {
            _userCommandHandler = userCommandHandler;
        }

        //public override void Configure()
        //{
        //    //Version(1); //1 is default
        //    Post("user");
        //    //Verbs(Http.POST, Http.PUT, Http.Patch);
        //    //Routes("/api/user/create", "/api/user/save");
        //    //Get("/customer/{@cid}/invoice/{@inv}", x => new { x.CustomerId, x.InvoiceId });
        //    AllowFormData();
        //    AllowAnonymous();
        //    Summary(s =>
        //    {
        //        s.Summary = "add user";
        //        s.Description = "blablabla";
        //    });
        //}

        //public override async Task HandleAsync(AddUserHandlerReq req, CancellationToken cancellationToken)
        //{
        //    Response<AddUserHandlerResp> response = await _userCommandHandler.AddUserHandlerAsync(req, cancellationToken);

        //    await SendAsync(response);
        //}
    }
}