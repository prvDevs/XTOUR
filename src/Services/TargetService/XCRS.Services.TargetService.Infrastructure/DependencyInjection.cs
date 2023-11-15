using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using XCRS.Services.TargetService.Domain.Interfaces.Repositories;
using XCRS.Services.TargetService.Domain.Settings;
using XCRS.Services.TargetService.Infrastructure.Repositories;

namespace XCRS.Services.TargetService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbSettings
            services.Configure<TargetsDbSettings>(configuration.GetSection("DbSettings:TargetsDbSettings"));
            services.AddSingleton<ITargetDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<TargetsDbSettings>>().Value); 
            #endregion

            #region Repositories
            services.AddScoped<ITargetsRepository, TargetsRepository>();
            #endregion

            return services;
        }
    }
}