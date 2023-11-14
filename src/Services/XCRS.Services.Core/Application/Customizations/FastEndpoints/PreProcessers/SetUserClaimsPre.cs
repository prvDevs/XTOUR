using FastEndpoints;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace XCRS.Services.Core.Application.Customizations.FastEndpoint.PreProcessers
{
    //public class SetUserClaimsPre<TRequest> : IPreProcessor<TRequest>
    //{
    //    public Task PreProcessAsync(TRequest req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
    //    {
    //        try
    //        {
    //            string token = StringUtil.ToString(ctx.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last());
    //            var handler = new JwtSecurityTokenHandler();
    //            var jsonToken = handler.ReadToken(token);
    //            var tokenS = jsonToken as JwtSecurityToken;
    //            var ptId = StringUtil.ToString(tokenS.Claims.First(claim => claim.Type == "sub")?.Value ?? "");
    //            ctx.Items["ptId"] = ptId;
    //        }
    //        catch (Exception)
    //        {
    //            ctx.Items["ptId"] = string.Empty;
    //        }

    //        return Task.CompletedTask;
    //    }
    //}
}


