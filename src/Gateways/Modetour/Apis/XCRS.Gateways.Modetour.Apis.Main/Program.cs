using XCRS.Gateways.Apis.Main.Customizations.Swagger;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;
using Ocelot.Cache.CacheManager;
using XCRS.Gateways.Core.Application.Customizations.Extensions;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
 .SetBasePath(Directory.GetCurrentDirectory())
 .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
 .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
 .AddJsonFile($"ocelot.json", optional: false, reloadOnChange: true)
 .AddJsonFile($"ocelot.{env}.json", optional: true, reloadOnChange: true)
 .AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration).AddPolly().AddConsul().AddCacheManager(x =>
{
    x.WithDictionaryHandle();
});
builder.Services.AddSwaggerForOcelot(builder.Configuration,
  (o) =>
  {
      o.GenerateDocsForGatewayItSelf = true;
  }
);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerForOcelotUI(options =>
    {
        options.PathToSwaggerGenerator = "/swagger/docs";
        options.ReConfigureUpstreamSwaggerJson = AlterStream.AlterUpstreamSwaggerJson;
        //options.DownstreamSwaggerHeaders = new[]
        //{
        //    new KeyValuePair<string, string>("Auth-Key", "AuthValue"),
        //};
        //options.ServerOcelot = "/siteName/apigateway";

    }).UseOcelot().Wait();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
