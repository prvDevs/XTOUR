using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XCRS.Services.TargetService.Application.UseCases.Commands;
using XCRS.Services.TargetService.Application.UseCases.Commands.Cases;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Commands;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Commands.Cases;

namespace XCRS.Services.TargetService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            #region Cases
            services.AddScoped<IAddTargetCases, AddTargetCases>();
            #endregion

            #region CommandHandlers
            services.AddScoped<ITargetCommandHandler, TargetCommandHandler>();
            #endregion


            return services;
        }
    }
}