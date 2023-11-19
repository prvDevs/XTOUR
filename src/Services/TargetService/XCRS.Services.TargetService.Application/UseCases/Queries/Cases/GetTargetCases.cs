using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCRS.Core.Domain.Dtos;
using XCRS.Services.TargetService.Application.TargetCases.Validations;
using XCRS.Services.TargetService.Domain.Dtos.UseCases.Commands.Cases.Responses;
using XCRS.Services.TargetService.Domain.Entities;
using XCRS.Services.TargetService.Domain.Interfaces.Repositories;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Queries.Cases;

namespace XCRS.Services.TargetService.Application.UseCases.Queries.Cases
{
    public class GetTargetCases : IGetTargetCases
    {
        private readonly IUnitOfWork _uow;

        public GetTargetCases(IUnitOfWork uow) { 
            _uow = uow;
        }
        public async Task<IEnumerable<Target>> GetTargetsAsync() {
            #region validation                   
            #endregion

            #region Case

            var r =  await _uow.TargetRepository.GetAllAsync().ConfigureAwait(false);
            #endregion

            #region Modification            
            #endregion

            return r;            
        }


        public async Task<Target> GetTargetByIdAsync(string id) {
            #region validation                   
            #endregion

            #region Case

            var r = await _uow.TargetRepository.FindByIdAsync(id).ConfigureAwait(false);
            #endregion

            #region Modification            
            #endregion

            return r;
        } 

    }
}
