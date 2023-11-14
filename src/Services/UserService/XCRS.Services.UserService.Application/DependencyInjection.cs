using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XCRS.Services.UserService.Domain.Interfaces.Application.UseCases.Commands;
using XCRS.Services.UserService.Domain.Interfaces.Application.UseCases.Quereis;
using XCRS.Services.UserService.Application.UseCases.Commands;
using XCRS.Services.UserService.Application.UseCases.Queries;

namespace XCRS.Services.UserService.Application
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            #region CommandHandlers
            services.AddScoped<IUserCommandHandler, UserCommandHandler>(); 
            #endregion

            #region QueryHandlers
            services.AddScoped<IUserQueryHandler, UserQueryHandler>();
            #endregion

            return services;
        }
    }
}
