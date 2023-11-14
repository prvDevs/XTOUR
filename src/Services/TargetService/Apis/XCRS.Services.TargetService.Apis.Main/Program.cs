using FastEndpoints.Swagger;
using Microsoft.Extensions.Options;
using XCRS.Services.Core;
using XCRS.Services.Core.Domain.Settings;
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

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
