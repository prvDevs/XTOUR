using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XCRS.Services.TargetService.Domain.Interfaces.Repositories;
using XCRS.Services.TargetService.Infrastructure.Repositories;

namespace XCRS.Services.TargetService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories
            services.AddScoped<ITargetsRepository, TargetsRepository>();
            #endregion

            return services;
        }
    }
}