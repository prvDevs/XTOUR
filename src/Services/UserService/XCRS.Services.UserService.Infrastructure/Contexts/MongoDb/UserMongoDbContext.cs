﻿using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;
using MongoDB.Driver;
using XCRS.Services.Core.Domain.Settings;

namespace XCRS.Services.UserService.Infrastructure.Contexts.MongoDb
{
    public class UserMongoDbContext : IMongoContext
    {
        public UserMongoDbContext(IMongoDbSettings connectionSetting)
        {
            //Console.WriteLine($"=====================> [{nameof(UserMongoDbContext)}] Mongo connection: {connectionSetting.GetConnectionString()}");
            //var client = new MongoClient(connectionSetting.GetConnectionString());
            //Database = client.GetDatabase(connectionSetting.GetDatabaseName());
        }

        public IMongoDatabase Database { get; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}