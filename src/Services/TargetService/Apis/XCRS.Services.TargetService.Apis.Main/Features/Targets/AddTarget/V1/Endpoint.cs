using Microsoft.AspNetCore.Mvc;
using System.Net;
using XCRS.Core.Domain.Dtos;
using XCRS.Services.TargetService.Application.Features.Targets;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Handlers.Requests;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Handlers.Responses;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Commands;

namespace XCRS.Services.TargetService.Apis.Main.Features.Targets.AddTarget.V1
{
    [ProducesResponseType(typeof(Response<AddTargetHandlerResp>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
    public class AddTargetAsync : BaseTargetCommandHandlerEndpoint<AddTargetHandlerReq, Response<AddTargetHandlerResp>>
    {
        private readonly ITargetCommandHandler _targetCommandHandler;

        public AddTargetAsync(ITargetCommandHandler targetCommandHandler)
        {
            _targetCommandHandler = targetCommandHandler;
        }

        public override void Configure()
        {
            Post("target");
            AllowFormData();
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "add target";
            });
        }

        public override async Task HandleAsync(AddTargetHandlerReq req, CancellationToken cancellationToken)
        {
            Response<AddTargetHandlerResp> response = await _targetCommandHandler.AddTargetHandlerAsync(req, cancellationToken);

            await SendAsync(response);
        }
    }
}
