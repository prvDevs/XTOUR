using Microsoft.EntityFrameworkCore;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Contexts;

namespace XCRS.Services.UserService.Infrastructure.Contexts
{
    public class ModeWeb3DbContext : BaseContext, IModeWeb3DbContext
    {
        public ModeWeb3DbContext(DbContextOptions<ModeWeb3DbContext> options) : base(options)
        {
            
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data/TestDb/ModeWeb3");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}