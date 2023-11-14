﻿using XCRS.Services.Core.Domain.Settings;
using XCRS.Services.Core.Infrastructure.Repository;
using XCRS.Services.TargetService.Domain.Entities;
using XCRS.Services.TargetService.Domain.Interfaces.Repositories;

namespace XCRS.Services.TargetService.Infrastructure.Repositories
{
    public class TargetsRepository : GenericMongoDbRepository<Target>, ITargetsRepository
    {
        public TargetsRepository(IMongoDbSettings settings) :  base(settings){ 
        }
    }
}
