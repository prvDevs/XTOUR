using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using XCRS.Gateways.Core.Application.Customizations.Extensions;
using System.IdentityModel.Tokens.Jwt;


namespace XCRS.Gateways.Core.Application.Customizations.Extensions
{
    public static class AuthenticationExtensions
    {

        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = configuration.GetValue<string>("Authentication:Authority");

                    // BELOW ARE FOR TESTING.
                    // TODO: control by env variable
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                        {
                            var jwt = new JwtSecurityToken(token);
                            return jwt;
                        },
                        ValidateActor = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = false,
                        ValidateLifetime = false,
                        ValidateTokenReplay = false
                    };
                });
            services.AddAuthorization(options =>
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "openid", "profile", "modetour_member", "ptid");
                })
            );
        }
    }
}
