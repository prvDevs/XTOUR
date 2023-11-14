using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XCRS.Services.UserService.Helper
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddHelper(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
