using XCRS.Core.Domain.Dtos;
using XCRS.Services.Core.Application.Customizations.Extensions;
using XCRS.Services.TargetService.Application.UseCases.Commands.Cases;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Cases.Requests;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Cases.Responses;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Handlers.Requests;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Handlers.Responses;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Commands.Cases;

namespace XCRS.Services.TargetService.Application.UseCases.Commands.Handlers
{
    public class AddTargetHandler
    {
        private readonly IAddTargetCases _addTargetCases;
        public AddTargetHandler(
            IAddTargetCases addTargetCases)
        {
            _addTargetCases = addTargetCases;
        }

        public async Task<Response<AddTargetHandlerResp>> HandleAsync(AddTargetHandlerReq req, CancellationToken cancellationToken)
        {
            #region Init
            Response<AddTargetHandlerResp> r = new();
            #endregion

            try
            {
                AddTargetCaseReq addTargetCaseReq = new()
                {
                    Code = req.Code,
                    TargetBi = new TargetBiCaseReq
                    {
                        Address = req.TargetBi.Address,
                        Ceo = req.TargetBi.Ceo,
                        Domain = req.TargetBi.Domain,
                        Email = req.TargetBi.Email,
                        NameKo = req.TargetBi.NameKo,
                        NameEn = req.TargetBi.NameEn,
                        PhoneNo = req.TargetBi.PhoneNo,
                    },
                    TargetResource = new TargetResourceCaseReq
                    {
                        ColorSetCode = req.TargetResource.ColorSetCode,
                        GnbBannerUrl = req.TargetResource.GnbBannerUrl,
                        LoginBannerUrl = req.TargetResource.LoginBannerUrl
                    }
                };

                AddTargetCaseResp addTargetCaseResp = await _addTargetCases.AddTargetCase(addTargetCaseReq, cancellationToken).ConfigureAwait(false);
                if (!addTargetCaseResp.IsSuccess)
                {
                    if (addTargetCaseResp.ErrorResult.IsInvalid)
                        r.AddCustomServiceValidatorErrorMessage(addTargetCaseResp.ErrorResult.ErrorValues);
                    return r;
                }


                r.Result = new AddTargetHandlerResp
                {
                    Id = addTargetCaseResp.Id
                };
            }
            catch (Exception ex)
            {
                r.AddCustomServiceException(ex);
            }

            return r;
        }
    }
}
