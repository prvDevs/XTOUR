using XCRS.Core.Domain.Dtos;
using XCRS.Services.TargetService.Application.TargetCases.Validations;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Cases.Requests;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Cases.Responses;
using XCRS.Services.TargetService.Domain.Entities;
using XCRS.Services.TargetService.Domain.Interfaces.Repositories;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Commands.Cases;

namespace XCRS.Services.TargetService.Application.UseCases.Commands.Cases
{
    public class AddTargetCases : IAddTargetCases
    {
        private readonly IUnitOfWork _uow;
        public AddTargetCases(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<AddTargetCaseResp> AddTargetCase(AddTargetCaseReq req, CancellationToken cancellationToken)
        {
            #region Init
            AddTargetCaseResp r = new AddTargetCaseResp
            {
                ErrorResult = new ErrorResult { ErrorValues = new string[0] }
            };
            #endregion

            #region validation       
            ValidationResult codeValidationResult = TargetValidation.ValidateCode(req.Code);
            ValidationResult nameEnValidationResult = TargetValidation.ValidateCode(req.TargetBi.NameEn);
            ValidationResult nameKoValidationResult = TargetValidation.ValidateCode(req.TargetBi.NameKo);

            if (codeValidationResult.IsInvalid && codeValidationResult.ErrorValues.Length > 0)
                r.ErrorResult.ErrorValues = r.ErrorResult.ErrorValues.Concat(codeValidationResult.ErrorValues).ToArray();
            if (nameEnValidationResult.IsInvalid && nameEnValidationResult.ErrorValues.Length > 0)
                r.ErrorResult.ErrorValues = r.ErrorResult.ErrorValues.Concat(nameEnValidationResult.ErrorValues).ToArray();
            if (nameKoValidationResult.IsInvalid && nameKoValidationResult.ErrorValues.Length > 0)
                r.ErrorResult.ErrorValues = r.ErrorResult.ErrorValues.Concat(nameKoValidationResult.ErrorValues).ToArray();

            if (r.ErrorResult.ErrorValues != null && r.ErrorResult.ErrorValues.Length > 0)
            {
                r.ErrorResult.IsInvalid = true;
                return r;
            }
            #endregion

            #region Case
            Target target = new Target
            {
                Code = req.Code,
                TargetBi = new TargetBi { 
                    Address = req.TargetBi.Address,
                    Ceo = req.TargetBi.Ceo,
                    Domain = req.TargetBi.Domain,
                    Email = req.TargetBi.Email,
                    NameKo = req.TargetBi.NameKo,
                    NameEn = req.TargetBi.NameEn,
                    PhoneNo = req.TargetBi.PhoneNo,
                },
                TargetResource = new TargetResource
                {
                    ColorSetCode = req.TargetResource.ColorSetCode,
                    GnbBannerUrl = req.TargetResource.GnbBannerUrl,
                    LoginBannerUrl = req.TargetResource.LoginBannerUrl
                }
            };

            await _uow.TargetRepository.InsertOneAsync(target).ConfigureAwait(false);
            #endregion

            #region Result
            if (target.Id == null)
                r.ErrorResult.AddDefaultErrorValues();
            else {
                r.Id = target.Id.ToString();
                r.IsSuccess = true;
            }
            #endregion

            return r;
        }
    }
}
