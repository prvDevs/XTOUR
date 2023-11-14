using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using XCRS.Core.Utility;
using XCRS.Services.Core.Application.Customizations.Authorizations.Policies.Requirements;
using System.IdentityModel.Tokens.Jwt;

namespace XCRS.Services.Core.Application.Customizations.Authorizations.Policies
{
    public class HasPtIdHandler : AuthorizationHandler<HasPtIdRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HasPtIdHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPtIdRequirement requirement)
        {
            try
            {
                string token = StringUtil.ToString(_httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last());
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;
                var ptId = StringUtil.ToString(tokenS?.Claims.First(claim => claim.Type == "sub")?.Value ?? "");

                if (string.IsNullOrWhiteSpace(ptId))
                {
                    _httpContextAccessor.HttpContext.Items["ptId"] = ptId;
                    context.Succeed(requirement);
                }
                else
                    context.Fail();
            }
            catch (Exception)
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
