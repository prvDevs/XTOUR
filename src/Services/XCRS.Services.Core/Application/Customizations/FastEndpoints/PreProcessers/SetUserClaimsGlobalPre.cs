using FastEndpoints;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using XCRS.Core.Utility;
using System.IdentityModel.Tokens.Jwt;

namespace XCRS.Services.Core.Application.Customizations.FastEndpoints.PreProcessers
{
    public class SetUserClaimsGlobalPre : IGlobalPreProcessor
    {
        public Task PreProcessAsync(object req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
        {
            try
            {
                string token = StringUtil.ToString(ctx.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last());
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;
                var ptId = StringUtil.ToString(tokenS.Claims.First(claim => claim.Type == "sub")?.Value ?? "");
                ctx.Items["ptId"] = ptId;
            }
            catch (Exception)
            {
                ctx.Items["ptId"] = string.Empty;
            }

            return Task.CompletedTask;
        }
    }
}
