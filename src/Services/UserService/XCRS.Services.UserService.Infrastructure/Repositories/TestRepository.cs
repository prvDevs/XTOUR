using Microsoft.EntityFrameworkCore;
using XCRS.Services.UserService.Core.Entities;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;
using XCRS.Services.UserService.Infrastructure.Repositories.UoW;

namespace XCRS.Services.UserService.Infrastructure.Repositories
{
    public class TestRepository : GenericRepository<User>, ITestRepository
    {
        public TestRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}