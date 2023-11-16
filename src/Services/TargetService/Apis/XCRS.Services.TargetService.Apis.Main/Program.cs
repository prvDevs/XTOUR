using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using XCRS.Services.Core;
using XCRS.Services.Core.Application.Customizations.FastEndpoints.PreProcessers;
using XCRS.Services.TargetService.Application;
using XCRS.Services.TargetService.Helper;
using XCRS.Services.TargetService.Infrastructure;

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
builder.Services.AddGraphQLServer();
builder.Services.SwaggerDocument(o =>
{
    o.MaxEndpointVersion = 1;
    o.DocumentSettings = s =>
    {
        s.DocumentName = "v1";
        s.Title = "XCRS Target Service v1";
        s.Version = "v1";
    };
});
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(b => b
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);
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
app.UseDefaultExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.Run();