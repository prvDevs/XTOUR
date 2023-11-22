using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XCRS.Services.TargetService.Application.UseCases.Commands;
using XCRS.Services.TargetService.Application.UseCases.Commands.Cases;
using XCRS.Services.TargetService.Application.UseCases.Queries;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Commands;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Commands.Cases;
using HotChocolate.Types;
using XCRS.Core.Entities.UserService.Core.Entities;
using XCRS.Services.TargetService.Domain.Entities;
using MongoDB.Bson;
using XCRS.Services.TargetService.Domain.Interfaces.UseCases.Queries.Cases;
using XCRS.Services.TargetService.Application.UseCases.Queries.Cases;

namespace XCRS.Services.TargetService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            #region Cases
            services.AddScoped<IAddTargetCases, AddTargetCases>();


            services.AddScoped<IGetTargetCases, GetTargetCases>();            
            #endregion

            #region CommandHandlers
            services.AddScoped<ITargetCommandHandler, TargetCommandHandler>();
            #endregion

            #region Queries
            services.AddGraphQLServer()
                    //.AddTypeConverter<string, ObjectId>(from => ObjectId.Parse(from))
                    .AddTypeConverter<ObjectId, string>(from => from.ToString())
                    .BindRuntimeType<ObjectId, IdType>()                  
                    .AddQueryType<TargetQuery>(); 
            #endregion

            return services;
        }
    }
}