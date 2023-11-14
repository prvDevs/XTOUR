using Microsoft.EntityFrameworkCore;
using XCRS.Services.UserService.Core.Entities;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Contexts;

namespace XCRS.Services.UserService.Infrastructure.Contexts
{
    public class NewEagle3DbContext : BaseContext, INewEagle3DbContext
    {
        public NewEagle3DbContext(DbContextOptions<NewEagle3DbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}