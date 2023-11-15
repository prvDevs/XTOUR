using XCRS.Core.Domain.Dtos;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Handlers.Requests;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Handlers.Responses;

namespace XCRS.Services.TargetService.Domain.Interfaces.UseCases.Commands
{
    public interface ITargetCommandHandler
    {
        #region Add
        Task<Response<AddTargetHandlerResp>> AddTargetHandlerAsync(AddTargetHandlerReq req, CancellationToken cancellationToken);
        #endregion
    }
}
