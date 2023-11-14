using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;
using XCRS.Services.UserService.Infrastructure.Contexts;
using XCRS.Services.UserService.Infrastructure.Repositories.UoW;

namespace XCRS.Services.UserService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContexts
            services.AddDbContext<ModeWeb3DbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("ModeWeb3Connection"));
            });
            services.AddDbContext<NewEagle3DbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("NewEagle3Connection"));
            });
            #endregion

            #region UoWs
            services.AddScoped<IModeWeb3UoW, ModeWeb3UoW>();
            services.AddScoped<INewEagle3UoW, NewEagle3UoW>(); 
            #endregion

            return services;
        }
    }
}