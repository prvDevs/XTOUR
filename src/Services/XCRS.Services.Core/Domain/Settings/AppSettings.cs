﻿namespace XCRS.Services.Core.Domain.Settings
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }

   
}
