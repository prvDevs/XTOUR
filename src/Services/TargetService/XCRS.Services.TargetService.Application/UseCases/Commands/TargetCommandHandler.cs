using XCRS.Core.Domain.Dtos;
using XCRS.Services.TargetService.Application.UseCases.Commands.Handlers;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Handlers.Requests;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Handlers.Responses;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Commands;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Commands.Cases;

namespace XCRS.Services.TargetService.Application.UseCases.Commands
{
    public class TargetCommandHandler : ITargetCommandHandler
    {

        private readonly IAddTargetCases _addTargetCases;
        public TargetCommandHandler(IAddTargetCases addTargetCases)
        {
            _addTargetCases = addTargetCases;
        }

        #region Add
        public async Task<Response<AddTargetHandlerResp>> AddTargetHandlerAsync(AddTargetHandlerReq req, CancellationToken cancellationToken)
            => await new AddTargetHandler(_addTargetCases).HandleAsync(req, cancellationToken);
        #endregion
        
        #region Update
        #endregion

        #region Delete

        #endregion

        #region Send

        #endregion

        #region Upload

        #endregion
    }
}
