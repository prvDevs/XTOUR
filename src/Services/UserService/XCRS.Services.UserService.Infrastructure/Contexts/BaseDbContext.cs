using Microsoft.EntityFrameworkCore;
using XCRS.Services.UserService.Core.Entities;

namespace XCRS.Services.UserService.Infrastructure.Contexts
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
