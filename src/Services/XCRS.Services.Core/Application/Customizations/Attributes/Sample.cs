using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace XCRS.Services.Core.Application.Customizations.Attributes
{
    //
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    //public class SetUserClaimsToContextItemsAttribute : Attribute, IActionFilter
    //{

    //    public void OnActionExecuting(ActionExecutingContext context) {
    //        try
    //        {
    //            string token = StringUtil.ToString(context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last());
    //            var handler = new JwtSecurityTokenHandler();
    //            var jsonToken = handler.ReadToken(token);
    //            var tokenS = jsonToken as JwtSecurityToken;
    //            var ptId = StringUtil.ToString(tokenS.Claims.First(claim => claim.Type == "sub")?.Value ?? "");
    //            context.HttpContext.Items["ptId"] = ptId;
    //        }
    //        catch (Exception ex)
    //        {
    //            context.HttpContext.Items["ptId"] = string.Empty;
    //        }
    //    }

    //    public void OnActionExecuted(ActionExecutedContext context) { 
    //    }
    //}
}
