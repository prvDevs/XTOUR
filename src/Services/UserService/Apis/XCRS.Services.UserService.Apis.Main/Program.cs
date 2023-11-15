global using FastEndpoints;
using XCRS.Services.Core;
using XCRS.Services.UserService.Helper;
using XCRS.Services.UserService.Application;
using XCRS.Services.UserService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using FastEndpoints.Swagger;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using XCRS.Services.Core.Application.Customizations.FastEndpoints.PreProcessers;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration
 .SetBasePath(Directory.GetCurrentDirectory())
 .AddJsonFile($"appsettings.json", optional: false)
 .AddJsonFile($"appsettings.{env}.json", optional: true)
 .AddEnvironmentVariables();

builder.Services
    .AddCore(builder.Configuration)
    .AddHelper(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApplication(builder.Configuration);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
{
    o.MaxEndpointVersion = 1;
    o.DocumentSettings = s =>
    {
        s.DocumentName = "v1";
        s.Title = "XCRS User Service v1";
        s.Version = "v1";
    };
});
    //.SwaggerDocument(o =>
    //{
    //    o.MaxEndpointVersion = 2;
    //     o.DocumentSettings = s =>
    //    {
    //        s.DocumentName = "Release 2";
    //        s.Title = "XCRS v2";
    //        s.Version = "v2";
    //    };
    //});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
});
//builder.Services.AddJWTBearerAuth("TokenSigningKey");
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy(nameof(DefaultPolicyConst.NeedUserClaimsFromHeader),
//        policyBuilder =>
//            policyBuilder.AddRequirements(
//                new HasPtIdRequirement()
//            ));
//});

var app = builder.Build();
app.UseCors(b => b
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);
app.UseDefaultExceptionHandler();
//app.UseAuthentication();
//app.UseAuthorization();
//customize error response of FastEndpoint validation
app.UseFastEndpoints(c =>
{
    c.Versioning.Prefix = "v";
    c.Versioning.DefaultVersion = 1;
    //c.Versioning.PrependToRoute = true;
    c.Endpoints.RoutePrefix = "api";
    c.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    c.Errors.ResponseBuilder = (failures, ctx, statusCode) =>
    {
        return new ValidationProblemDetails(
            failures.GroupBy(f => f.PropertyName)
                    .ToDictionary(
                        keySelector: e => e.Key,
                        elementSelector: e => e.Select(m => m.ErrorMessage).ToArray()))
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Title = "One or more validation errors occurred.",
            Status = statusCode,
            Instance = ctx.Request.Path,
            Extensions = { { "traceId", ctx.TraceIdentifier } }
        };
    };

    c.Endpoints.Configurator = ep =>
    {
        ep.PreProcessors(Order.Before, new SetUserClaimsGlobalPre());
    };
    //c.Endpoints.Filter = ep =>
    //{
    //    if (ep.Verbs.Contains("GET") && ep.Routes.Contains("/api/mobile/test"))
    //    {
    //        return false; // don't register this endpoint
    //    }
    //    return true;
    //};
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}
app.UseHttpsRedirection();
//app.UseCors(b => b
//    .AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//);
app.MapControllers();
app.Run();